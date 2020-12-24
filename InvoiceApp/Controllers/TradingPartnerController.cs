using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceApp.Models;
using Microsoft.Extensions.Logging;

namespace InvoiceApp.Controllers
{
    public class TradingPartnerController : Controller
    {
        private IOrderManager manager;
        private ILogger logger;

        public TradingPartnerController(IOrderManager orderManager, ILogger<HomeController> log)
        {
            manager = orderManager;
            logger = log;
        }
        public ActionResult Index(string id)
        {
            TradingPartner partner = manager.GetTradingPartner(id);
            return View(partner);
        }
    }
}