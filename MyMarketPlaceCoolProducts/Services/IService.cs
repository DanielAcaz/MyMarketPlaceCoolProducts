using System;
using System.Collections.Generic;
using MyMarketPlaceCoolProducts.Models;

namespace MyMarketPlaceCoolProducts.Services
{
    public interface IService
    {
        IEnumerable<Product> GetProducts();

        Product DeleteById(string _Id);

        Product CreateProduct(Product _Product);

        Product GetById(string _Id);

        Product UpdateProduct(Product Product, string Id);
    }
}
