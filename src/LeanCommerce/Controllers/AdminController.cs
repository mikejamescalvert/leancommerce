using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using LeanCommerce.Abstract.Controllers;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeanCommerce.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : AbstractSetupRequiredController
    {
        public AdminController(Services.MongoSettings.Service.IMongoSettingsService mongoService) : base(mongoService)
        {

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
