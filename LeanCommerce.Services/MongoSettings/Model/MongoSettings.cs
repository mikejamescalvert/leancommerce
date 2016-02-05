using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.MongoSettings.Model
{
    public class MongoSettings
    {
        public string MongoDBName { get; set; }
        public string MongoDBUrl { get; set; }
        public bool AdminCreated { get; set; }
        public bool SiteSetup { get; set; }
    }
}
