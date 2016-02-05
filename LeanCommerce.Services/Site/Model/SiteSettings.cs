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
    }
}
