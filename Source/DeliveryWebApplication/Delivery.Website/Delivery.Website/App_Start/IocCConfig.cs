using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Delivery.BL;
using Delivery.BL.Contracts;
using Delivery.DAL;
using Delivery.DAL.Contracts;
using Delivery.DAL.Repositories;
using Delivery.Website.Areas.Admin.Contracts;
using Delivery.Website.Areas.Admin.Services;
using Delivery.Website.Areas.Public.Profiles;
using NLog;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;

namespace Delivery.Website.App_Start
{
    public static class IocCConfig
    {
        public static void Initialize()
        {
            var container = Register(new ContainerBuilder());
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static IContainer Register(ContainerBuilder containerBuilder)
        {
            //controller
            containerBuilder.RegisterControllers(Assembly.Load("Delivery.Website"));

            //dbcontext
            containerBuilder.RegisterType<DeliveryContextFactory>()
                .InstancePerDependency()
                .WithParameter("url", ConfigurationManager.ConnectionStrings["DeliveryDatabase"].ConnectionString);

            //repository
            containerBuilder.RegisterType<CargoRepository>().As<ICargoRepository>();
            containerBuilder.RegisterType<ContactRepository>().As<IContactRepository>();
            containerBuilder.RegisterType<DriverRepository>().As<IDriverRepository>();
            containerBuilder.RegisterType<RouteRepository>().As<IRouteRepository>();
            containerBuilder.RegisterType<WarehouseRepository>().As<IWarehouseRepository>();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();

            //services
            containerBuilder.RegisterType<CargoService>().As<ICargoService>();
            containerBuilder.RegisterType<WarehouseService>().As<IWarehouseService>();
            containerBuilder.RegisterType<ContactService>().As<IContactService>();
            containerBuilder.RegisterType<DriverService>().As<IDriverService>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<RouteService>().As<IRouteService>();
            containerBuilder.RegisterType<SecurityService>().As<ISecurityService>();

            containerBuilder.RegisterType<FileGenerator>().As<IFileGenerator>();

            //mapper
            containerBuilder.Register(c => new MapperConfiguration(config =>
            {
                config.AddProfile<ContactProfile>();
                config.AddProfile<GeoProfile>();
            })).AsSelf().SingleInstance();

            containerBuilder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>();

            //logger
            containerBuilder.RegisterInstance(LogManager.GetCurrentClassLogger()).As<ILogger>();

            return containerBuilder.Build();
        }
    }
}