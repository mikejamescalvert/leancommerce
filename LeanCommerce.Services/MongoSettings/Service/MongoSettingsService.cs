using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Newtonsoft.Json;

namespace LeanCommerce.Services.MongoSettings.Service
{
    public class MongoSettingsService : IMongoSettingsService
    {
        EncryptionSettings.Service.IEncryptionSettingsService _encryptionService;
        public MongoSettingsService(EncryptionSettings.Service.IEncryptionSettingsService encryptionService)
        {
            _encryptionService = encryptionService;
            LoadSettings();
        }

        private MongoSettings.Model.MongoSettings MongoSettings { get; set; }
        public string MongoDBUrl
        {
            get
            {
                return MongoSettings.MongoDBUrl;
            }
            set
            {
                MongoSettings.MongoDBUrl = value;
            }
        }
        public string MongoDBName
        {
            get
            {
                return MongoSettings.MongoDBName;
            }
            set
            {
                MongoSettings.MongoDBName = value;
            }
        }

        public void SaveSettings()
        {
            string settingsPath = (string)AppDomain.CurrentDomain.GetData("DataDirectory") + "/mongosettings.config";
            string data = JsonConvert.SerializeObject(MongoSettings);
            data = _encryptionService.EncryptValue(data);
            System.IO.File.WriteAllText(settingsPath, data);
        }
        public void LoadSettings()
        {

            string settingsPath = (string)AppDomain.CurrentDomain.GetData("DataDirectory") + "/mongosettings.config";
            if (System.IO.File.Exists(settingsPath) == true && _encryptionService!= null && _encryptionService.RequiresSetup() == false)
            {
                string data = System.IO.File.ReadAllText(settingsPath);
                data = _encryptionService.DecryptValue(data);
                MongoSettings = JsonConvert.DeserializeObject<Model.MongoSettings>(data);
            }
            if (MongoSettings == null)
                ResetSettings();

        }
        public void ResetSettings()
        {
            MongoSettings = new Model.MongoSettings();
        }
        public bool RequiresSetup()
        {
            if (string.IsNullOrEmpty(MongoSettings.MongoDBName) || 
                string.IsNullOrEmpty(MongoSettings.MongoDBUrl) ||
                _encryptionService.RequiresSetup()
                )
                return true;

            

            return false;
        }
    }
}
