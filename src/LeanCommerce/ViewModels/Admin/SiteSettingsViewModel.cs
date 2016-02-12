using LeanCommerce.Services.Site.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LeanCommerce.ViewModels.Admin
{
    public class SiteSettingsViewModel
    {
        [Required]
        [Display(Name ="Site Name")]
        public string SiteName { get; set; }
        public ObjectId Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedInURL { get; set; }
        public string DribbbleURL { get; set; }
        public string GooglePlusURL { get; set; }

        public SiteSettingsViewModel()
        {

        }
        public SiteSettingsViewModel(SiteSettings settings)
        {
            SiteName = settings.SiteName;
            PhoneNumber = settings.PhoneNumber;
            Email = settings.Email;
            FacebookURL = settings.FacebookURL;
            TwitterURL = settings.TwitterURL;
            LinkedInURL = settings.LinkedInURL;
            DribbbleURL = settings.DribbbleURL;
            GooglePlusURL = settings.GooglePlusURL;
        }
        public void CopyToSiteSettings(SiteSettings settings)
        {
            settings.SiteName = SiteName;
            settings.PhoneNumber = PhoneNumber;
            settings.Email = Email;
            settings.FacebookURL = FacebookURL;
            settings.TwitterURL = TwitterURL;
            settings.LinkedInURL = LinkedInURL;
            settings.DribbbleURL = DribbbleURL;
            settings.GooglePlusURL = GooglePlusURL;
        }
    }
}
