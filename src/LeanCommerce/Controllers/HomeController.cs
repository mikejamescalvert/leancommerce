using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using LeanCommerce.Models;

namespace LeanCommerce.Controllers
{
    public class HomeController : Abstract.Controllers.AbstractSetupRequiredController
    {
        public HomeController(Services.MongoSettings.Service.IMongoSettingsService mongoService) : base(mongoService)
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
