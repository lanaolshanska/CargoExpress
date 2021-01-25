using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Public.Controllers
{
    [ErrorHandling]
    [Secured(UserRoles = new Role[] { Role.Public })]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult Info()
        {
            User user = (User)HttpContext.Items["User"];
            var contact = _contactService.FindContactByUserId(user.Id);
            if (contact != null)
            {
                return View(contact);
            }
            else
            {
                var contactInfo = new Contact
                {
                    Email = user.Email,
                    UserId = user.Id
                };
                _contactService.Create(contactInfo);
                return View(contactInfo);
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {
            User user = (User)HttpContext.Items["User"];
            return View(_contactService.FindContactByUserId(user.Id));
        }

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(contact);
                return RedirectToAction("Info");
            }
            else
            {
                return View(contact);
            }
        }
    }
}