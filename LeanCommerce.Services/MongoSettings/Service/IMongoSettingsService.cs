using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.MongoSettings.Service
{
    public interface IMongoSettingsService
    {
        string MongoDBName { get; set; }
        string MongoDBUrl { get; set; }
        void SaveSettings();
        Task TestConnection();
        bool RequiresSetup();
        event EventHandler SettingsChanged;
    }
}
