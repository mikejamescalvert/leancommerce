using LeanCommerce.Services.Catalog.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Catalog.Service
{
    public interface IProductService
    {
        IMongoCollection<Product> Products { get; }
        Product GetProductById(ObjectId productId);
        IList<Product> GetCategoriesForProduct(ObjectId productId, bool active);
        Task SaveProduct(Product product);
        Task DeleteProduct(ObjectId productId);
    }
}
