using LeanCommerce.Services.Site.Service;
using LeanCommerce.ViewModels.Shared;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewComponents
{
    public class SiteFooterViewComponent : ViewComponent
    {
        private ISiteSettingsService _siteSettingsService;
        public SiteFooterViewComponent(ISiteSettingsService siteSettingsService)
        {
            _siteSettingsService = siteSettingsService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new SiteSettingsViewModel(_siteSettingsService.CurrentSiteSettings));
        }

    }
}
