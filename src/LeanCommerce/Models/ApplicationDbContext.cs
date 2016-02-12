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
using LeanCommerce.Core.User.Model;

namespace LeanCommerce.Models
{
    public class ApplicationDbContext : AspNet.Identity3.MongoDB.MongoIdentityContext<ApplicationUser, AspNet.Identity3.MongoDB.IdentityRole>
    {
        IMongoSettingsService _dbService;
        public ApplicationDbContext(IMongoSettingsService dbService)
        : base()
        {
            _dbService = dbService;
            if (_dbService != null)
            {
                _dbService.SettingsChanged += DbService_SettingsChanged;
                SetupContext();
            }


        }

        private void SetupContext()
        {
            this.Users = _dbService.GetMongoCollection<ApplicationUser>("users");
            this.Roles = _dbService.GetMongoCollection<AspNet.Identity3.MongoDB.IdentityRole>("roles");
        }

        private void DbService_SettingsChanged(object sender, EventArgs e)
        {
            SetupContext();
        }
        

    }
}
