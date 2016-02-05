using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanCommerce.Services.Site.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LeanCommerce.Services.Site.Service
{
    public class SiteSettingsService : ISiteSettingsService
    {
        private IMongoCollection<SiteSettings> _SiteSettings;
        public IMongoCollection<SiteSettings> SiteSettings
        {
            get
            {
                if (_SiteSettings == null)
                    LoadSiteSettings();
                return _SiteSettings;
            }
        }
        public SiteSettings DefaultSiteSettings {
            get
            {
                if (SiteSettings == null)
                    return null;

                return SiteSettings.Find(x=>x.DefaultSite == true).FirstOrDefaultAsync().Result;
            }
        }

        public SiteSettings CurrentSiteSettings
        {
            get
            {
                if (CurrentSiteId == ObjectId.Empty)
                    return DefaultSiteSettings;


                return SiteSettings.Find(x => x.Id == CurrentSiteId).FirstOrDefaultAsync().Result;
            }
        }

        public ObjectId CurrentSiteId { get; set; }

        private MongoSettings.Service.IMongoSettingsService _dbService;
        public SiteSettingsService(MongoSettings.Service.IMongoSettingsService dbService)
        {
            _dbService = dbService;
            _dbService.SettingsChanged += _dbService_SettingsChanged;
            
            LoadSiteSettings();
        }

        private void _dbService_SettingsChanged(object sender, EventArgs e)
        {
            LoadSiteSettings();
        }

        void LoadSiteSettings()
        {
            if (string.IsNullOrEmpty(_dbService.MongoDBName) == false && string.IsNullOrEmpty(_dbService.MongoDBUrl) == false)
            {
                string connectionString = _dbService.MongoDBUrl;
                string databaseName = _dbService.MongoDBName;
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                _SiteSettings = database.GetCollection<SiteSettings>("sitesettings");
            }
        }

        public void InsertUpdateSite(SiteSettings site)
        {
            if (site.Id == null)
            {
                var filter = Builders<SiteSettings>.Filter.Eq(s => s.Id, site.Id);
                var result = SiteSettings.ReplaceOneAsync(filter, site).Result;
            } else
            {
                SiteSettings.InsertOneAsync(site);
            }
        }
    }
}
