using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using LeanCommerce.ViewModels.Setup;
using Microsoft.Extensions.OptionsModel;
using LeanCommerce.Models;
using Microsoft.AspNet.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeanCommerce.Controllers
{
    public class SetupController : Controller
    {
        Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        Services.EncryptionSettings.Service.IEncryptionSettingsService _encryptionService;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public SetupController(Services.MongoSettings.Service.IMongoSettingsService mongoService,
                                Services.EncryptionSettings.Service.IEncryptionSettingsService encryptionService,
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager) : base()
        {
            _mongoService = mongoService;
            _encryptionService = encryptionService;
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> DbSetup(DbSetupViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                _mongoService.MongoDBName = model.MongoDatabaseName;
                _mongoService.MongoDBUrl = model.MongoURL;
                try
                {
                    await _mongoService.TestConnection();
                    _encryptionService.SetEncryptionKey(model.EncryptionKey);
                    _mongoService.SaveSettings();
                    return RedirectToAction("AdminUser");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred connecting to the Mongo Database: " + ex.Message);
                }
            }
            return View(model);
        }

        public IActionResult AdminUser()
        {
            return View(new AdminUserViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AdminUser(AdminUserViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                //todo: try to create an admin user
                try
                {
                    
                    var user = new ApplicationUser { UserName = model.EmailAddress, Email = model.EmailAddress };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("SetupComplete");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        
                    }


                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred creating an admin user: " + ex.Message);
                }
            }
            return View(model);
        }

        public IActionResult SetupComplete()
        {
            return View();
        }
    }
}
