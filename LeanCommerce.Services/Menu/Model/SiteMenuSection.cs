using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Menu.Model
{
    public class SiteMenuSection : MenuSection
    {
        public List<ObjectId> siteIds;
    }
}
