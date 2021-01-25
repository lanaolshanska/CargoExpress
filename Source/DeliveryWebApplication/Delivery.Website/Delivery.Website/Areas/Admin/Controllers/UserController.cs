using Delivery.BL;
using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using System.Web.Mvc;
using PagedList;

namespace Delivery.Website.Areas.Admin.Controllers
{
    [ErrorHandling]
    [Secured(UserRoles = new Role[] { Role.Admin })]
    public class UserController : Controller
    {
        private const int startPage = 1;
        private const int pageSize = 20;

        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;

        public UserController(IUserService userService, IDriverService driverService, ISecurityService securityService)
        {
            _securityService = securityService;
            _userService = userService;
            _driverService = driverService;
        }

        [HttpGet]
        public ActionResult List(int? page)
        {
            var users = _userService.GetAll();
            var model = users.ToPagedList(page ?? startPage, pageSize);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user.Role == Role.Driver)
            {
                _driverService.DeleteByUserId(id);
            }
            _userService.Delete(id);
            return RedirectToAction("List");
        }
    }
}