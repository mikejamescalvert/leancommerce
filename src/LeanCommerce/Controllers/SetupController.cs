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
        Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        Services.EncryptionSettings.Service.IEncryptionSettingsService _encryptionService;
        public SetupController(Services.MongoSettings.Service.IMongoSettingsService mongoService,
                                Services.EncryptionSettings.Service.IEncryptionSettingsService encryptionService) : base()
        {
            _mongoService = mongoService;
            _encryptionService = encryptionService;
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
            if (ModelState.IsValid == true)
            {
                _mongoService.MongoDBName = model.MongoDatabaseName;
                _mongoService.MongoDBUrl = model.MongoURL;
                _encryptionService.SetEncryptionKey(model.EncryptionKey);
                _mongoService.SaveSettings();
            }

            return View();
        }
    }
}
