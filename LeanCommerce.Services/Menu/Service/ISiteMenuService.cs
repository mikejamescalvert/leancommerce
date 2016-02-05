using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Menu.Service
{
    public interface ISiteMenuService : IMenuService
    {
        ObjectId SiteId { get; set; }
    }
}
