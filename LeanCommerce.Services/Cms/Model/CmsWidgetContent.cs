using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Cms.Model
{
    public class CmsWidgetContent
    {
        public ObjectId Id { get; set; }
        public string CodeName { get; set; }
        public string WidgetContents { get; set; }
    }
}
