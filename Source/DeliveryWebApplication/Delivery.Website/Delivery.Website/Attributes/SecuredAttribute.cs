using Delivery.BL.Contracts;
using Delivery.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System;

namespace Delivery.Website.Areas.Admin.Attributes
{
    public class SecuredAttribute : AuthorizeAttribute
    {
        private ISecurityService SecurityService
        {
            get
            {
                return DependencyResolver.Current.GetService<ISecurityService>();
            }
        }

        public Role[] UserRoles { get; set; } = new Role[] { Role.Admin, Role.Driver, Role.Public };
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie tokenCookie = httpContext.Request.Cookies.Get("UToken");
            if (tokenCookie == null || string.IsNullOrEmpty(tokenCookie.Value) || !IsRequestValid(tokenCookie.Value))
            {
                if (tokenCookie != null)
                {
                    httpContext.Response.Cookies.Get("UToken").Expires = DateTime.Now.AddDays(-1);
                }
                httpContext.Items.Remove("User");
                return false;
            }
            else
            {
                tokenCookie.Expires = DateTime.Now.AddDays(7);
                httpContext.Items["User"] = SecurityService.GetUser(tokenCookie.Value);
                return true;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Start",
                                action = "Authorization",
                                area = ""
                            })
                        );
        }

        private bool IsRequestValid(string token)
        {
            bool IsValid = false;
            if (SecurityService.IsSessionExists(token))
            {
                User authorizedUser = SecurityService.GetUser(token);
                IsValid = UserRoles.Any(role => role == authorizedUser.Role);
            }
            return IsValid;
        }
    }
}