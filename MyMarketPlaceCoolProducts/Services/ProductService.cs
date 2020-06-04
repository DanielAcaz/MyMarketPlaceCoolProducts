using System;
using System.Collections.Generic;
using System.Linq;
using MyMarketPlaceCoolProducts.Error;
using MyMarketPlaceCoolProducts.Model;

namespace MyMarketPlaceCoolProducts.Services
{
    public class ProductService : IService
    {

        private static IList<Product> Products = new List<Product>(new Product[]
            {
                Product.BuildProduct("Produto1", "DescricaoDoProduto1", "ImagemDoProduto1", 100.0),
                Product.BuildProduct("Produto2", "DescricaoDoProduto2", "ImagemDoProduto2", 100.0),
                Product.BuildProduct("produto2", "DescricaoDoProduto3", "ImagemDoProduto3", 100.0)
            });

        public ProductService()
        {
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        public Product DeleteById(long _Id)
        {
            Product productWillDeleted = SearchProductById(_Id);
            Products.Remove(productWillDeleted);
            return productWillDeleted;
        }

        public Product CreateProduct(Product _Product)
        {
            Product NewProduct = Product.BuildProduct(
                _Product.Title,
                _Product.Description,
                _Product.ImageUrl,
                _Product.Price
            );

            if (NewProduct is Product.EmptyProduct)
                throw new InvalidProductException("This product is invalid!");

            Products.Add(NewProduct);

            return NewProduct;
        }

        public Product GetById(long _Id)
        {
            return SearchProductById(_Id);
        }

        private Product SearchProductById(long _Id)
        {
            return Products.DefaultIfEmpty(new Product.EmptyProduct())
                .Where(product => product.GetId() == _Id)
                .FirstOrDefault();
        }
    }
}
