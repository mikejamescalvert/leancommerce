using LeanCommerce.Services.Site.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Site.Service
{
    public interface ISiteSettingsService
    {
        SiteSettings DefaultSiteSettings { get; }
        IMongoCollection<SiteSettings> SiteSettings { get; }
        SiteSettings CurrentSiteSettings { get; }
        ObjectId CurrentSiteId { get; set; }
        void InsertUpdateSite(SiteSettings site);
    }
}
