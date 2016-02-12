using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Site.Model
{
    public class SiteSettings
    {
        public ObjectId Id { get; set; }
        public string SiteName { get; set; }
        public bool DefaultSite { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedInURL { get; set; }
        public string DribbbleURL { get; set; }
        public string GooglePlusURL { get; set; }
    }
}
