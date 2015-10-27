using Autofac;
using Autofac.Integration.WebApi;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.Service;
using InventoryManagement.WebAPI.Controllers;
using InventoryManagement.WebAPI.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace InventoryManagement.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            config.DependencyResolver = SetAutofacContainer();

            // Web API AutoMapperConfiguration
            AutoMapperConfiguration.Configure();

            // Web API JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
             
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }


        private static IDependencyResolver SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(StatusController).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();


            // Repositories
            builder.RegisterAssemblyTypes(typeof(EquipmentRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(EquipmentService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            return (new AutofacWebApiDependencyResolver(container));
        }
    }
}
