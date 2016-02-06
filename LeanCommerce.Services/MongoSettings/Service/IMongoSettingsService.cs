using Microsoft.AspNet.Http;
using MongoDB.Driver;
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
        bool AdminCreated { get; set; }
        bool SiteSetup { get; set; }
        void SaveSettings();
        Task TestConnection();
        bool RequiresSetup();
        event EventHandler SettingsChanged;
        IMongoCollection<T> GetMongoCollection<T>(string tableName);
    }
}
