using AutoMapper;
using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Website.Areas.Admin.Attributes;
using Delivery.Website.Areas.Public.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Delivery.Website.Areas.Public.Controllers
{
    [ErrorHandling]
    [Secured(UserRoles = new Role[] { Role.Public })]
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly IWarehouseService _warehouseService;
        private readonly IContactService _contactService;
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public CargoController(ICargoService cargoService, 
            IWarehouseService warehouseService, 
            IContactService contactService, 
            IRouteService routeService,
            IMapper mapper)
        {
            _cargoService = cargoService;
            _warehouseService = warehouseService;
            _contactService = contactService;
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult List(string paramName, bool? isAsc, bool enableSwitch = false)
        {
            User user = (User)HttpContext.Items["User"];
            var model = _cargoService.FilterByUser(user.Id);

            ViewBag.Order = isAsc ?? true;
            if (enableSwitch)
            {
                ViewBag.Order = !ViewBag.Order;
            }
            ViewBag.LastParameter = paramName;
            
            model = _cargoService.Sort(model, paramName, ViewBag.Order);
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _cargoService.GetById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            User user = (User)HttpContext.Items["User"];
            var sender = _contactService.FindContactByUserId(user.Id);
            var defaultSender = _mapper.Map<Contact, CargoContactModel>(sender);

            var warehouseStates = _warehouseService.GetStates();
            var states = _mapper.Map<IEnumerable<Warehouse>, IEnumerable<StateModel>>(warehouseStates);

            var model = new OrderModel
            {
                Sender = defaultSender,
                Recipient = new CargoContactModel(),
                OrigPlace = new CargoPlaceModel { States = states },
                DestPlace = new CargoPlaceModel { States = states }
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult GetCities(int stateId)
        {
            var warehouseCities = _warehouseService.GetCities(stateId);
            var cities = _mapper.Map<IEnumerable<Warehouse>, IEnumerable<CityModel>>(warehouseCities);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(OrderModel orderModel)
        {
            User user = (User)HttpContext.Items["User"];
            if (ModelState.IsValid)
            {

                var sender = _mapper.Map<CargoContactModel, Contact>(orderModel.Sender);
                sender.UserId = user.Id;
                int senderId = _contactService.CreateContact(sender);

                var recipient = _mapper.Map<CargoContactModel, Contact>(orderModel.Recipient);
                int recipientId = _contactService.CreateContact(recipient);

                var routeId = _routeService.GetRouteByWarehousesId(orderModel.OrigPlace.CityId, orderModel.DestPlace.CityId);

                var cargo = new Cargo
                {
                    RouteId = routeId,
                    Weight = orderModel.Weight,
                    Volume = orderModel.Volume,
                    SenderContactId = senderId,
                    RecipientContactId = recipientId,
                    UserId = user.Id,
                    Status = CargoStatus.New
                };
                _cargoService.Create(cargo);

                return RedirectToAction("List", "Cargo", new { area = "Public" });
            }
            else
            {
                return View(orderModel);
            }
        }
    }
}