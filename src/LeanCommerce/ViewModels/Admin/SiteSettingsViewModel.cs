using LeanCommerce.Services.Site.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewModels.Admin
{
    public class SiteSettingsViewModel
    {
        [Required]
        [Display(Name ="Site Name")]
        public string SiteName { get; set; }

        public SiteSettingsViewModel()
        {

        }
        public SiteSettingsViewModel(SiteSettings settings)
        {
            SiteName = settings.SiteName;
        }

    }
}
