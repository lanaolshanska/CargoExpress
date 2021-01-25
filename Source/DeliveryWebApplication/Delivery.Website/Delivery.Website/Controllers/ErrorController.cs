using System.Web.Mvc;

namespace Delivery.Website.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Unexpected(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}