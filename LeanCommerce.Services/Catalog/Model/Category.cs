using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Catalog.Model
{
    public class Category
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
