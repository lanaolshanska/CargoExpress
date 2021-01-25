using AutoMapper;
using Delivery.BL;
using Delivery.BL.Contracts;
using Delivery.DAL;
using Delivery.DAL.Contracts;
using Delivery.DAL.Repositories;
using Delivery.Models;
using Delivery.Validators;
using Delivery.WebAPI.Models;
using Delivery.WebAPI.Profiles;
using Delivery.Website.Areas.Public.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Delivery.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(options => Configuration.GetSection("Database").Bind(options));

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                             .AddFluentValidation();
            services.AddCors();
            services.AddOptions();
            services.AddSingleton<AppSettings>();

            var settingsSection = Configuration.GetSection("Database");
            var appSettings = settingsSection.Get<AppSettings>();

            services.AddSingleton(appSettings);

            services.AddSingleton<DeliveryContextFactory>(provider => new DeliveryContextFactory(provider.GetService<AppSettings>().ConnectionString));

            services.AddSingleton<IWarehouseRepository, WarehouseRepository>();
            services.AddSingleton<IContactRepository, ContactRepository>();
            services.AddSingleton<ICargoRepository, CargoRepository>();
            services.AddSingleton<IRouteRepository, RouteRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IDriverRepository, DriverRepository>();
            
            services.AddSingleton<IWarehouseService, WarehouseService>();
            services.AddSingleton<IContactService, ContactService>();
            services.AddSingleton<ICargoService, CargoService>();
            services.AddSingleton<IRouteService, RouteService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IDriverService, DriverService>();

            services.AddSingleton<DriverValidator>(provider => new DriverValidator(provider.GetService<IDriverService>()));
            services.AddSingleton<UpdateDriverValidator>(provider => new UpdateDriverValidator(provider.GetService<IDriverService>()));
            services.AddSingleton<DeleteDriverValidator>(provider => new DeleteDriverValidator(provider.GetService<IDriverService>()));

            services.AddSingleton<CargoValidator>(provider => new CargoValidator(provider.GetService<ICargoService>(), provider.GetService<IContactService>(), provider.GetService<IWarehouseService>()));
            services.AddSingleton<UpdateCargoValidator>(provider => new UpdateCargoValidator(provider.GetService<ICargoService>(), provider.GetService<IContactService>(), provider.GetService<IWarehouseService>()));
            services.AddSingleton<DeleteCargoValidator>(provider => new DeleteCargoValidator(provider.GetService<ICargoService>()));

            services.AddSingleton<ContactValidator>(provider => new ContactValidator(provider.GetService<IContactService>()));
            services.AddSingleton<UpdateContactValidator>(provider => new UpdateContactValidator(provider.GetService<IContactService>()));
            services.AddSingleton<DeleteContactValidator>(provider => new DeleteContactValidator(provider.GetService<IContactService>()));

            services.AddSingleton<UserValidator>(provider => new UserValidator(provider.GetService<IUserService>()));
            services.AddSingleton<UpdateUserValidator>(provider => new UpdateUserValidator(provider.GetService<IUserService>()));
            services.AddSingleton<DeleteUserValidator>(provider => new DeleteUserValidator(provider.GetService<IUserService>()));

            services.AddSingleton<WarehouseValidator>(provider => new WarehouseValidator(provider.GetService<IWarehouseService>()));
            services.AddSingleton<UpdateWarehouseValidator>(provider => new UpdateWarehouseValidator(provider.GetService<IWarehouseService>()));
            services.AddSingleton<DeleteWarehouseValidator>(provider => new DeleteWarehouseValidator(provider.GetService<IWarehouseService>()));

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DTOProfile());
                mc.AddProfile(new GeoProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Cargo Express API", Version = "v1" });
                // Configure Swagger to use the xml documentation file
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                c.IncludeXmlComments(xmlFile);
                c.AddFluentValidationRules();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.ConfigureCustomExceptionMiddleware();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cargo Express API V1");
            });
        }
    }
}