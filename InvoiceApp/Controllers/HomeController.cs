using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceApp.Models;
using Microsoft.Extensions.Logging;

namespace InvoiceApp.Controllers
{
    public class HomeController : Controller
    {
        private IOrderManager manager;
        private ILogger logger;

        public HomeController(IOrderManager orderManager, ILogger<HomeController> log)
        {
            manager = orderManager;
            logger = log;
        }
        public ActionResult Index()
        {
            var orders = manager.GetPartnersList();
            return View(orders);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}