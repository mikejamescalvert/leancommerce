using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using LeanCommerce.ViewModels.Setup;
using Microsoft.Extensions.OptionsModel;
using LeanCommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Routing;
using AspNet.Identity3.MongoDB;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeanCommerce.Controllers
{
    public class SetupController : Controller
    {
        Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        Services.EncryptionSettings.Service.IEncryptionSettingsService _encryptionService;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public SetupController(Services.MongoSettings.Service.IMongoSettingsService mongoService,
                                Services.EncryptionSettings.Service.IEncryptionSettingsService encryptionService,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<ApplicationUser> signInManager) : base()
        {
            _mongoService = mongoService;
            _encryptionService = encryptionService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
                //try to create an admin user
                try
                {
                    
                    var user = new ApplicationUser { UserName = model.EmailAddress, Email = model.EmailAddress };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    
                    if (result.Succeeded)
                    {
                        //assign user to new admin role
                        var role = new IdentityRole { Name = "Admin" };
                        var roleResult = await _roleManager.CreateAsync(role);
                        if (roleResult.Succeeded)
                        {
                            var assignResult = await _userManager.AddToRoleAsync(user, "Admin");
                            if (assignResult.Succeeded)
                            {
                                await _signInManager.SignInAsync(user, isPersistent: false);
                                return RedirectToAction("SetupComplete");
                            } else {
                                foreach (var item in assignResult.Errors)
                                {
                                    ModelState.AddModelError("", item.Description);
                                }
                            }

                        }
                        else
                        {
                            foreach (var item in roleResult.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }

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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (_mongoService != null && _mongoService.RequiresSetup() == false)
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                    {{"controller", "Home"}, {"action", "Index"}});


            base.OnActionExecuting(context);
        }

    }
}
