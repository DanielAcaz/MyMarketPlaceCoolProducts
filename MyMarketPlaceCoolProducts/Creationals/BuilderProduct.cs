using System;
using MyMarketPlaceCoolProducts.Models;

namespace MyMarketPlaceCoolProducts.Creationals
{
    public class BuilderProduct
    {

        private Product _product;

        public BuilderProduct()
        {
            _product = new Product();
        }

        public BuilderProduct Id(string id)
        {
            _product.Id = id;
            return this;
        }

        public BuilderProduct Title(string title)
        {
            _product.Title = title;
            return this;
        }

        public BuilderProduct Description(string description)
        {
            _product.Description = description;
            return this;
        }

        public BuilderProduct ImageUrl(string imageUrl)
        {
            _product.ImageUrl = imageUrl;
            return this;
        }

        public BuilderProduct Price(double price)
        {
            _product.Price = price;
            return this;
        }

        public Product Build()
        {
            return _product;
        }

    }
}
