using LeanCommerce.Services.Catalog.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Catalog.Service
{
    public interface ICategoryService
    {
        IMongoCollection<Category> Categories { get; }
        Category GetCategoryById(ObjectId categoryId);
        IList<Category> GetRootCategories(bool active);
        IList<Category> GetRootCategories(ObjectId siteId, bool active);
        IList<Product> GetProductsForCategory(ObjectId categoryID, bool active);
    }
}
