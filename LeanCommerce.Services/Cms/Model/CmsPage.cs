using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Cms.Model
{
    public class CmsPage
    {
        public ObjectId Id { get; set; }
        public string PageName { get; set; }
        public string UrlName { get; set; }
        public string PageContents { get; set; }
    }
}
