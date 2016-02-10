using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanCommerce.Services.Catalog.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LeanCommerce.Services.Catalog.Service
{
    public class ProductService : IProductService
    {
        private Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        public ProductService(Services.MongoSettings.Service.IMongoSettingsService mongoService)
        {
            _mongoService = mongoService;
            _products = _mongoService.GetMongoCollection<Product>("product");
        }
        IMongoCollection<Product> _products;
        public IMongoCollection<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = _mongoService.GetMongoCollection<Product>("product");
                }
                return _products;
            }
        }

        public Task DeleteProduct(ObjectId productId)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetCategoriesForProduct(ObjectId productId, bool active)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(ObjectId productId)
        {
            if (Products == null)
                return null;

            return Products.AsQueryable().FirstOrDefault<Product>(x => x.Id == productId);
        }

        public async Task SaveProduct(Product product)
        {
            Product result = Products.AsQueryable().FirstOrDefault<Product>(x => x.Id == product.Id);
            if (result != null)
                await Products.FindOneAndReplaceAsync(x => x.Id == product.Id, product);
            else
                await Products.InsertOneAsync(product);
        }
    }
}
