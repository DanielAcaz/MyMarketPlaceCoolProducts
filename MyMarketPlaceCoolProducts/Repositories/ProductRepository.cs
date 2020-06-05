using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MyMarketPlaceCoolProducts.DAO;
using MyMarketPlaceCoolProducts.Error;
using MyMarketPlaceCoolProducts.Models;

namespace MyMarketPlaceCoolProducts.Repositories
{
    public class ProductRepository : IRepository<Product, string>
    {

        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IProductDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _products = database
                .GetCollection<Product>(settings.ProductsCollectionName);
        }

        public IList<Product> FindAll()
        {
            return _products.Find(product => true).ToList();
        }

        public Product FindById(string id) => _products.Find(product => product.Id.Equals(id))
            .FirstOrDefault();

        public Product InsertOne(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public bool RemoveOne(Product product) => _products
            .DeleteOne(_product => _product.Id == product.Id).DeletedCount == 1;

        public Product UpdateOne(Product product, string id)
        {
            if(_products.ReplaceOne(_product => _product.Id == id, product)
                .ModifiedCount == 1)
                return product;
            throw new InvalidProductException("Canno't update this product");
        }
    }
}
