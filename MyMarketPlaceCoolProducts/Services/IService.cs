using System;
using System.Collections.Generic;
using MyMarketPlaceCoolProducts.Model;

namespace MyMarketPlaceCoolProducts.Services
{
    public interface IService
    {
        IEnumerable<Product> GetProducts();

        Product DeleteById(long _Id);

        Product CreateProduct(Product _Product);

        Product GetById(long _Id);

        Product UpdateProduct(Product Product, long Id);
    }
}
