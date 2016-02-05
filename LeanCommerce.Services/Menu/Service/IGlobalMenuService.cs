using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Menu.Service
{
    interface IGlobalMenuService
    {
        List<ISiteMenuService> SiteMenuServices { get; set; }
        ISiteMenuService GetSiteMenuServiceBySiteId(ObjectId siteId);
    }
}
