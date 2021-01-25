using System.Web.Mvc;

namespace Delivery.Website.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "",
                "Admin/Warehouse/Cities/{state}",
                new { controller = "Warehouse", action = "Cities", state = UrlParameter.Optional },
                new[] { "Delivery.Website.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_Warehouse",
                "Admin/{controller}/{action}/{id}",
                new { controller = "User", action = "Registration", id = UrlParameter.Optional },
                new[] { "Delivery.Website.Areas.Admin.Controllers" }
            );
        }
    }
}