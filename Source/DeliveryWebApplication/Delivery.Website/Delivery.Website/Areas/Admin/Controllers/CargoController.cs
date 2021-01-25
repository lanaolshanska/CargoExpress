using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using PagedList;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Admin.Controllers
{
    [ErrorHandling]
    [Secured(UserRoles = new Role[] { Role.Admin })]
    public class CargoController : Controller
    {
        private const int startPage = 1;
        private const int pageSize = 20;

        private readonly ICargoService _cargoService;
        private readonly IContactService _contactService;

        public CargoController(ICargoService cargoService, IContactService contactService)
        {
            _cargoService = cargoService;
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult List(int? page, string paramName, bool? isAsc, bool enableSwitch = false)
        {
            ViewBag.Order = isAsc ?? true;
            if (enableSwitch)
            {
                ViewBag.Order = !ViewBag.Order;
            }

            ViewBag.LastParameter = paramName;
            ViewBag.LastPageNumber = page;

            var cargos = _cargoService.GetAll();
            cargos = _cargoService.Sort(cargos, paramName, ViewBag.Order);
            var model = cargos.ToPagedList(page ?? startPage, pageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_cargoService.GetById(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        { 
            var model = _cargoService.GetById(id);
            ViewBag.Users = new SelectList(_contactService.GetAll(), "Id", "LastName");
            return View(_cargoService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                _cargoService.Update(cargo);
                return RedirectToAction("List");
            }
            else
            {
                return View(cargo);
            }
        }

        public ActionResult Delete(int id)
        {
            _cargoService.Delete(id);
            return RedirectToAction("List");
        }
    }
}