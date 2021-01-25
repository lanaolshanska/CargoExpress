using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using NLog;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Admin.Controllers
{
    [ErrorHandling]
    public class WarehouseController : Controller
    {
        private const int startPage = 1;
        private const int pageSize = 20;

        private readonly IWarehouseService _warehouseService;
        private readonly ILogger _logger;

        public WarehouseController(IWarehouseService warehouseService, ILogger logger)
        {
            _warehouseService = warehouseService;
            _logger = logger;
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

            var warehouses = _warehouseService.GetAll();
            warehouses = _warehouseService.Sort(warehouses, paramName, ViewBag.Order);
            var model = warehouses.ToPagedList(page ?? startPage, pageSize);

            return View(model);
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Create(string state = "")
        {
            var model = new Warehouse();
            if (!string.IsNullOrEmpty(state))
            {
                model.State = state.Trim();
            }
            return View(model);
        }

        [HttpPost]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Create(Warehouse warehouse)
        {
            _logger.Debug("Creating Warehouse");

            _warehouseService.Create(warehouse);
            return RedirectToAction("Cities", new { warehouse.State });
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin, Role.Driver, Role.Public })]
        public ActionResult Details(int id)
        {
            return View(_warehouseService.GetById(id));
        }

        [HttpGet]
        public ActionResult Cities(string State)
        {
            return View(_warehouseService.FilterBy(State));
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Edit(int id)
        {
            return View(_warehouseService.GetById(id));
        }

        [HttpPost]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Edit(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _logger.Debug("Updating Warehouse: Id = {0}", warehouse.Id);

                _warehouseService.Update(warehouse);
                return RedirectToAction("Cities", new { warehouse.State });
            }
            else
            {
                _logger.Error("Model was not valid: {0}", String.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage)));
                return View(warehouse);
            }
        }

        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Delete(int id)
        {
            _logger.Debug("Deleting warehouse: Id = {0}", id);

            _warehouseService.Delete(id);
            return RedirectToAction("List", new { id = 1 });
        }
    }
}