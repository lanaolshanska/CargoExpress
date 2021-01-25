using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using Delivery.Website.Areas.Admin.Contracts;
using PagedList;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Admin.Controllers
{
    [ErrorHandling]
    public class DriverController : Controller
    {
        private const int startPage = 1;
        private const int pageSize = 20;

        private readonly IDriverService _driverService;
        private readonly IFileGenerator _fileGenerator;

        public DriverController(IDriverService driverService, IFileGenerator fileGenerator)
        {
            _driverService = driverService;
            _fileGenerator = fileGenerator;
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult List(int? page, string paramName, bool? isAsc, bool enableSwitch = false)
        {
            ViewBag.Order = isAsc ?? true;
            if (enableSwitch)
            {
                ViewBag.Order = !ViewBag.Order;
            }

            ViewBag.LastParameter = paramName;
            ViewBag.LastPageNumber = page;

            var drivers = _driverService.GetAllValidDrivers();
            drivers = _driverService.Sort(drivers, paramName, ViewBag.Order);

            var model = drivers.ToPagedList(page ?? startPage, pageSize);

            return View(model);
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin, Role.Public })]
        public ActionResult Details(int id)
        {
            return View(_driverService.GetById(id));
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Edit(int id)
        {
            return View(_driverService.GetById(id));
        }

        [HttpPost]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _driverService.Update(driver);
                return RedirectToAction("List");
            }
            else
            {
                return View(driver);
            }
        }

        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Delete(int id)
        {
            _driverService.Delete(id);
            return RedirectToAction("List");
        }

        [Secured(UserRoles = new Role[] { Role.Admin })]
        public void Report()
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DriverReport.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            var data = _fileGenerator.GenerateDriverReport();

            Response.Output.Write(data.ToString());
            Response.Flush();
            Response.End();
        }
    }
}