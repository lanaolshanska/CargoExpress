using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Drivers.Controllers
{
    [ErrorHandling]
    [Secured(UserRoles = new Role[] { Role.Driver })]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        
        [HttpGet]
        public ActionResult Info()
        {
            User user = (User)HttpContext.Items["User"];
            var driver = _driverService.FindByUserId(user.Id);
            return View(driver);
        }

        [HttpPost]
        public ActionResult Info(int id)
        {
            var driver = _driverService.GetById(id);
            driver.Status = DriverStatus.Waiting;
            _driverService.Update(driver);
            return RedirectToAction("Info");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            User user = (User)HttpContext.Items["User"];
            return View(_driverService.FindByUserId(user.Id));
        }

        [HttpPost]
        public ActionResult Edit(Driver driver, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                _driverService.Update(driver);

                if (photo != null && photo.ContentLength > 0)
                {
                    var fileName = driver.Id.ToString() + ".jpg";
                    var path = Path.Combine(Server.MapPath("/Images/Photos/"), fileName);
                    photo.SaveAs(path);
                }

                return RedirectToAction("Info");
            }
            else
            {
                return View(driver);
            }
        }
    }
}