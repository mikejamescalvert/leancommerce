using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using System.Configuration;
using Microsoft.Extensions.OptionsModel;
using LeanCommerce.Services.MongoSettings.Service;

namespace LeanCommerce.Models
{
    public class ApplicationDbContext : AspNet.Identity3.MongoDB.MongoIdentityContext<ApplicationUser, AspNet.Identity3.MongoDB.IdentityRole>
    {
        
        public ApplicationDbContext(IMongoSettingsService dbService)
        : base()
        {
            if (dbService != null && dbService.RequiresSetup() == false)
            {
                string connectionString = dbService.MongoDBUrl;
                string databaseName = dbService.MongoDBName;
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                this.Users = database.GetCollection<ApplicationUser>("users");
                this.Roles = database.GetCollection<AspNet.Identity3.MongoDB.IdentityRole>("roles");
            }

        }
    }
}
