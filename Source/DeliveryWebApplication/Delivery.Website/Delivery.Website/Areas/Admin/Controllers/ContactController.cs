using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using PagedList;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Admin.Controllers
{
    [ErrorHandling]
    public class ContactController : Controller
    {
        private const int startPage = 1;
        private const int pageSize = 20;

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
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

            var contacts = _contactService.GetAll();
            contacts = _contactService.Sort(contacts, paramName, ViewBag.Order);
            var model = contacts.ToPagedList(page ?? startPage, pageSize);

            return View(model);
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin, Role.Public })]
        public ActionResult Details(int id)
        {
            return View(_contactService.GetById(id));
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Create(Contact contact)
        {
            _contactService.Create(contact);
            return RedirectToAction("List");
        }

        [HttpGet]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Edit(int id)
        {
            return View(_contactService.GetById(id));
        }

        [HttpPost]
        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(contact);
                return RedirectToAction("List");
            }
            else
            {
                return View(contact);
            }
        }

        [Secured(UserRoles = new Role[] { Role.Admin })]
        public ActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("List");
        }
    }
}