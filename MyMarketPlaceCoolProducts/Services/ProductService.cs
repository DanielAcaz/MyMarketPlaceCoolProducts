using System.Collections.Generic;
using MyMarketPlaceCoolProducts.Error;
using MyMarketPlaceCoolProducts.Model;
using MyMarketPlaceCoolProducts.Repositories;

namespace MyMarketPlaceCoolProducts.Services
{
    public class ProductService : IService
    {

        private IRepository<Product, long> Repository;

        public ProductService(IRepository<Product, long> _Repository)
        {
            Repository = _Repository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Repository.FindAll();
        }

        public Product DeleteById(long _Id)
        {
            Product Product = Repository.FindById(_Id);
            if(!(Product is Product.EmptyProduct))
                if (Repository.RemoveOne(Product))
                    return Repository.FindById(_Id);
            return new Product.EmptyProduct();
        }

        public Product CreateProduct(Product _Product)
        {
            Product NewProduct = Repository.InsertOne(_Product);
            if (NewProduct is Product.EmptyProduct)
                throw new InvalidProductException("This product is invalid!");
            return NewProduct;
        }

        public Product GetById(long _Id)
        {
            return Repository.FindById(_Id);
        }

        public Product UpdateProduct(Product _Product, long Id)
        {
            Product Product = Repository.FindById(Id);
            if(Product is Product.EmptyProduct)
                throw new InvalidProductException("This product is invalid!");

            Product.Title = _Product.Title;
            Product.ImageUrl = _Product.ImageUrl;
            Product.Description = _Product.Description;
            Product.Price = _Product.Price;

            Product ProductUpdated = Repository.UpdateOne(Product, Id);

            return ProductUpdated;
        }
    }
}
