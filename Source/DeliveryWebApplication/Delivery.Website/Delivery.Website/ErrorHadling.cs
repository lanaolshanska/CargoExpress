using NLog;
using System;
using System.Web.Mvc;

namespace Delivery.Website
{
    public class ErrorHandling : HandleErrorAttribute
    {
        private ILogger Logger
        {
            get
            {
                return DependencyResolver.Current.GetService<ILogger>();
            }
        }

        public override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            var area = filterContext.RouteData.DataTokens["area"];
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            var message = exception.Message;

            Logger.Error("{0} => {1} => {2}: Exception occured: {3}", area, controller, action, message);

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Error/Index.cshtml",
                ViewData = new ViewDataDictionary {
                        { "Exception", message},
                        { "Controller", controller },
                        { "Action", action }
                    }
            };
        }
    }
}