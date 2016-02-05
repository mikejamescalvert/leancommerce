using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LeanCommerce.Services.Menu.Service
{
    public class GlobalSiteMenuService : IGlobalMenuService
    {
        public GlobalSiteMenuService()
        {
            SiteMenuServices = new List<ISiteMenuService>();
        }
        public List<ISiteMenuService> SiteMenuServices { get; set; }

        public ISiteMenuService GetSiteMenuServiceBySiteId(ObjectId siteId)
        {
            foreach (var item in SiteMenuServices)
            {
                if (item.SiteId == siteId)
                    return item;
            }
            return null;
        }
    }
}
