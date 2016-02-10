using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanCommerce.Services.Catalog.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

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
            if (Categories == null)
                return null;

            return Categories.AsQueryable().FirstOrDefault<Category>(x => x.Id == categoryId);
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

        public async Task SaveCategory(Category category)
        {
            Category result = Categories.AsQueryable().FirstOrDefault<Category>(x => x.Id == category.Id);
            if (result != null)
                await Categories.FindOneAndReplaceAsync(x => x.Id == category.Id, category);
            else
                await Categories.InsertOneAsync(category);

        }

        public async Task DeleteCategory(ObjectId categoryId)
        {
            Category result = Categories.AsQueryable().FirstOrDefault<Category>(x => x.Id == categoryId);
            if (result != null)
                await Categories.DeleteOneAsync(x => x.Id == categoryId);
        }
    }
}
