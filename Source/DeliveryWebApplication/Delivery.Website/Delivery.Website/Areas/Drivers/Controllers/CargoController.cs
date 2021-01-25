using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Drivers.Controllers
{
    [ErrorHandling]
    [Secured(UserRoles = new Role[] { Role.Driver })]
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly IDriverService _driverService;

        public CargoController(ICargoService cargoService, IDriverService driverService)
        {
            _cargoService = cargoService;
            _driverService = driverService;
        }
        
        [HttpGet]
        public ActionResult DriverCargos(int id)
        {
            var model = _cargoService.FilterByDriver(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult NewCargos(CargoStatus status)
        {
            var model = _cargoService.FilterByStatus(status);
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Take(int cargoId)
        {
            User user = (User)HttpContext.Items["User"];

            var driver = _driverService.FindByUserId(user.Id);
            var cargo = _cargoService.GetById(cargoId);

            cargo.Status = CargoStatus.PickedUp;
            cargo.DriverId = driver.Id;
            _cargoService.Update(cargo);

            return RedirectToAction("DriverCargos", "Cargo", new { id = driver.Id });
        }
        
        [HttpGet]
        public ActionResult Complete(int cargoId)
        {
            User user = (User)HttpContext.Items["User"];

            var driver = _driverService.FindByUserId(user.Id);
            var cargo = _cargoService.GetById(cargoId);

            cargo.Status = CargoStatus.Completed;
            _cargoService.Update(cargo);

            driver.TripsTotal += 1;
            _driverService.Update(driver);

            return RedirectToAction("DriverCargos", "Cargo", new { id = driver.Id });
        }
    }
}