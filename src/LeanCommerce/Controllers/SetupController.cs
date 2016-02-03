using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using LeanCommerce.ViewModels.Setup;
using Microsoft.Extensions.OptionsModel;
using LeanCommerce.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeanCommerce.Controllers
{
    public class SetupController : Controller
    {
        AppSettings _settings;
        public SetupController(IOptions<AppSettings> options) : base()
        {
            _settings = options.Value;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/welcome
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult DbSetup()
        {
            return View(new DbSetupViewModel());
        }
        [HttpPost]
        public IActionResult DbSetup(DbSetupViewModel model)
        {
            //todo: test mongodb connection, show errors
            //todo: save app settings from model
            //todo: redirect to finish page
            return View();
        }
    }
}
