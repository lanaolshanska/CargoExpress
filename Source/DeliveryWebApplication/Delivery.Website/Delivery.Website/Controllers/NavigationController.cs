using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using Delivery.Website.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Admin.Controllers
{
    [Secured]
    public class NavigationController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IDriverService _driverService;

        private readonly Dictionary<Role, List<NavigationModel>> navigationConfig = new Dictionary<Role, List<NavigationModel>>()
        {
            { Role.Admin, new List<NavigationModel>()
                {
                    new NavigationModel { Title = "Users", Controller = "User", Action = "List", RouteParameters = new { area = "Admin" } },                   
                    new NavigationModel { Title = "Contacts", Controller = "Contact", Action = "List", RouteParameters = new { area = "Admin" } },
                    new NavigationModel { Title = "Cargoes", Controller = "Cargo", Action = "List", RouteParameters = new { area = "Admin" } },
                    new NavigationModel { Title = "Drivers", Controller = "Driver", Action = "List", RouteParameters = new { area = "Admin" } },
                    new NavigationModel { Title = "Warehouses", Controller = "Warehouse", Action = "List", RouteParameters = new { area = "Admin" }}
                }
            },
            { Role.Driver, new List<NavigationModel>()
                {
                    new NavigationModel { Title = "My Info", Controller = "Driver", Action = "Info", RouteParameters = new { area = "Drivers" } },
                }
            },
            { Role.Public, new List<NavigationModel>()
                {
                    new NavigationModel { Title = "My Info", Controller = "Contact", Action = "Info", RouteParameters = new { area = "Public" } },
                    new NavigationModel { Title = "Orders", Controller = "Cargo", Action = "List", RouteParameters = new { area = "Public" } },
                    new NavigationModel { Title = "Add new", Controller = "Cargo", Action = "Create", RouteParameters = new { area = "Public" } }
                }
            }
        };

        public NavigationController(IWarehouseService warehouseService, IDriverService driverService)
        {
            _driverService = driverService;
            _warehouseService = warehouseService;

            NavigationModel WarehouseModel = navigationConfig[Role.Admin].Find(Model => Model.Controller.Equals("Warehouse") && Model.Action.Equals("List"));
            if (WarehouseModel != null)
            {
                WarehouseModel.Submenu = _warehouseService.GetStates()
                    .Select(StateItem => new NavigationModel { Title = StateItem.State, Controller = "Warehouse", Action = "Cities", RouteParameters = new { area = "Admin", State = StateItem.State } })
                    .ToList();
            }
        }

        public ActionResult Navigation()
        {
            User user = (User)HttpContext.Items["User"];
            Driver driver = _driverService.FindByUserId(user.Id);
            if (user.Role == Role.Driver && driver.Status == DriverStatus.Approved)
            {
                navigationConfig[Role.Driver].Add(new NavigationModel { Title = "My Cargos", Controller = "Cargo", Action = "DriverCargos", RouteParameters = new { area = "Drivers", id = driver.Id } });
                navigationConfig[Role.Driver].Add(new NavigationModel { Title = "New Orders", Controller = "Cargo", Action = "NewCargos", RouteParameters = new { area = "Drivers", status = CargoStatus.New } });
            }
            return PartialView(navigationConfig[user.Role]);
        }
    }
}