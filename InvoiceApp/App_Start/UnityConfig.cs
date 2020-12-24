using System.Web.Mvc;
using DAL;
using InvoiceApp.Models;
using Unity;
using Unity.Mvc5;
using Microsoft.Extensions.Logging;
using Unity.Injection;

namespace InvoiceApp.App_Start
{
    public static class UnityConfig
    {

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            var loggerFactory = new LoggerFactory();
            container.RegisterType<IDataAccess, DataAccess>();
            container.RegisterInstance<ILoggerFactory>(loggerFactory);
            container.RegisterSingleton(typeof(ILogger<>), typeof(Logger<>));
            container.RegisterType<IOrderManager, OrderManager>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}