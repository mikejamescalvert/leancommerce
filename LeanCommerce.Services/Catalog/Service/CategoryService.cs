using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanCommerce.Services.Catalog.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LeanCommerce.Services.Catalog.Service
{
    public class CategoryService : ICategoryService
    {
        private Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        public CategoryService (Services.MongoSettings.Service.IMongoSettingsService mongoService)
        {
            _mongoService = mongoService;
            _categories = _mongoService.GetMongoCollection<Category>("category");
        }
        private IMongoCollection<Category> _categories;
        public IMongoCollection<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = _mongoService.GetMongoCollection<Category>("category");
                }
                return _categories;
            }
        }

        public Category GetCategoryById(ObjectId categoryId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsForCategory(ObjectId categoryID, bool active)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetRootCategories(bool active)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetRootCategories(ObjectId siteId, bool active)
        {
            throw new NotImplementedException();
        }
    }
}
