using Delivery.BL;
using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using Delivery.Website.Areas.Admin.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace Delivery.Website.Controllers
{
    public class StartController : Controller
    {
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;

        public StartController(IUserService userService, IDriverService driverService, ISecurityService securityService)
        {
            _securityService = securityService;
            _userService = userService;
            _driverService = driverService;
        }

        [HttpGet]
        public ActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.FindUserByEmailAndPassword(loginModel.Email, loginModel.Password);
                if (user != null)
                {
                    var token = _securityService.CreateNewSession(user.Id);
                    HttpContext.Response.SetCookie(new HttpCookie("UToken", token) { Expires = DateTime.Now.AddDays(7) });

                    switch (user.Role)
                    {
                        case Role.Admin:
                            return RedirectToAction("List", "User", new { area = "Admin" });
                        case Role.Driver:
                            return RedirectToAction("Info", "Driver", new { area = "Drivers" });
                        case Role.Public:
                            return RedirectToAction("List", "Cargo", new { area = "Public" });
                        default:
                            return RedirectToAction("Authorization", "Start", new { area = ""});
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The email address or password you entered does not exist or is invalid");
                    return View(loginModel);
                }
            }
            else
            {
                return View(loginModel);
            }
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (!_userService.IsEmailExist(registerModel.Email))
                {
                    var role = (registerModel.IsAdmin ? Role.Admin : registerModel.IsDriver ? Role.Driver : Role.Public);
                    int userId = _userService.Create(registerModel.UserName, registerModel.Password, registerModel.Email, role);

                    if (registerModel.IsDriver)
                    {
                        _driverService.Create(registerModel.FirstName, registerModel.LastName, userId);
                    }

                    var token = _securityService.CreateNewSession(userId);
                    HttpContext.Response.SetCookie(new HttpCookie("UToken", token) { Expires = DateTime.Now.AddDays(7) });

                    switch (role)
                    {
                        case Role.Admin:
                            return RedirectToAction("List", "User", new { area = "Admin" });
                        case Role.Driver:
                            return RedirectToAction("Info", "Driver", new { area = "Drivers" });
                        case Role.Public:
                            return RedirectToAction("List", "Cargo", new { area = "Public" });
                        default:
                            return RedirectToAction("Authorization", "Start", new { area = "" });
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The email address already exists");
                    return View(registerModel);
                }
            }
            else
            {
                return View(registerModel);
            }
        }
        
        [HttpGet]
        [Secured]
        public ActionResult LogOut()
        {
            _securityService.DeleteSession(HttpContext.Request.Cookies.Get("UToken").Value);

            HttpContext.Items.Remove("User");
            HttpContext.Response.Cookies.Get("UToken").Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Authorization", "Start", new { area = "" });
        }

        [HttpGet]
        public ActionResult RedirectToApi()
        {
            return Redirect("http://edu.delivery.api.com");
        }
    }
}