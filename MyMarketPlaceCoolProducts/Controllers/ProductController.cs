using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyMarketPlaceCoolProducts.Model;

namespace MyMarketPlaceCoolProducts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private static IList<Product> Products = new List<Product>(new Product[]
            {
                new Product("Produto1", "DescricaoDoProduto1", "ImagemDoProduto1", 100.0),
                new Product("Produto2", "DescricaoDoProduto2", "ImagemDoProduto2", 100.0),
                new Product("produto2", "DescricaoDoProduto3", "ImagemDoProduto3", 100.0)
            });

        public ProductController()
        {
        }

        [HttpGet]
        public IList<Product> Get()
        {
            return Products;
        }

        [HttpDelete]
        [Route("{_Id}")]
        public Product DeleteById(long _Id)
        {
            Product productWillDeleted = Products
                            .Where(product => product.GetId() == _Id)
                            .FirstOrDefault();
            if(Products.Remove(productWillDeleted))
            {
                return productWillDeleted;
            }
            throw new Exception("Cannot Delete This Product");
            
        }

        [HttpPost]
        public Product CreateProduct([FromBody] Product _product)
        {
            Product newProduct = new Product(
                _product.Title,
                _product.Description,
                _product.ImageUrl,
                _product.Price
            );

            Products.Add(newProduct);

            return newProduct;
        }
    }
}
