using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LeanCommerce.Services.Menu.Service
{
    public class SiteMenuService : MenuService, ISiteMenuService
    {
        public ObjectId SiteId { get; set; }

    }
}
