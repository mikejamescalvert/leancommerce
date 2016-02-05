using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using LeanCommerce.Abstract.Controllers;
using Microsoft.AspNet.Authorization;
using LeanCommerce.ViewModels.Admin;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeanCommerce.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : AbstractSetupRequiredController
    {
        Services.Site.Service.ISiteSettingsService _siteSettingsService;
        public AdminController(Services.MongoSettings.Service.IMongoSettingsService mongoService,
                    Services.Site.Service.ISiteSettingsService siteSettingsService) : base(mongoService)
        {
            _siteSettingsService = siteSettingsService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/SiteSettings
        public IActionResult SiteSettings()
        {
            return View(new SiteSettingsViewModel(_siteSettingsService.CurrentSiteSettings));
        }

        // POST: /<controller>/SiteSettings
        [HttpPost]
        public IActionResult SiteSettings(SiteSettingsViewModel model)
        {
            try
            {
                _siteSettingsService.CurrentSiteSettings.SiteName = model.SiteName;
                _siteSettingsService.InsertUpdateSite(_siteSettingsService.CurrentSiteSettings);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "There was an error updating the site information: " + ex.Message);
            }
            return View();
        }

    }
}
