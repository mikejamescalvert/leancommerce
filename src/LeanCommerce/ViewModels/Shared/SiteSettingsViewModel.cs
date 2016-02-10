using LeanCommerce.Services.Site.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewModels.Shared
{
    public class SiteSettingsViewModel
    {
        public SiteSettingsViewModel(SiteSettings settings)
        {
            if (settings == null)
            {
                PhoneNumber = "+2 95 01 88 821";
                SiteName = "Lean Commerce";
                Email = "info@leancommerce.com";
                FacebookURL = "#";
                TwitterURL = "#";
                LinkedInURL = "#";
                DribbbleURL = "#";
                GooglePlusURL = "#";
            } else
            {
                PhoneNumber = "+2 95 01 88 821";
                SiteName = settings.SiteName;
                Email = "info@leancommerce.com";
                FacebookURL = "#";
                TwitterURL = "#";
                LinkedInURL = "#";
                DribbbleURL = "#";
                GooglePlusURL = "#";
            }

        }
        public string SiteName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedInURL { get; set; }
        public string DribbbleURL { get; set; }
        public string GooglePlusURL { get; set; }
    }
}
