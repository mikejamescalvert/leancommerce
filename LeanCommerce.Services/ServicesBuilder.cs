using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LeanCommerce.Services
{
    public static class ServicesBuilder
    {
        public static void RegisterBaseServices(ref IServiceCollection services)
        {
            services.AddSingleton<MongoSettings.Service.IMongoSettingsService, MongoSettings.Service.MongoSettingsService>();
            services.AddSingleton<EncryptionSettings.Service.IEncryptionSettingsService, EncryptionSettings.Service.EncryptionSettingsService>();
        }
    }
}
