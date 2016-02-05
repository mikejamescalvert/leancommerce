using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Catalog.Model
{
    public class ProductCategoryRelationship
    {
        public ObjectId Id { get; set; }
        public ObjectId ProductId { get; set; }
        public ObjectId CategoryId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
