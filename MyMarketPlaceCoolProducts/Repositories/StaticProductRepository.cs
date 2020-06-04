using System.Collections.Generic;
using System.Linq;
using MyMarketPlaceCoolProducts.Model;

namespace MyMarketPlaceCoolProducts.Repositories
{
    public class StaticProductRepository: IRepository<Product,long>
    {

        private static readonly IList<Product> Products = new List<Product>(new Product[]
            {
                Product.BuildProduct("Produto1", "DescricaoDoProduto1", "ImagemDoProduto1", 100.0),
                Product.BuildProduct("Produto2", "DescricaoDoProduto2", "ImagemDoProduto2", 100.0),
                Product.BuildProduct("produto2", "DescricaoDoProduto3", "ImagemDoProduto3", 100.0)
            });

        public StaticProductRepository()
        {
        }

        public IList<Product> FindAll()
        {
            return Products;
        }

        public Product FindById(long _Id)
        {
            return Products.DefaultIfEmpty(new Product.EmptyProduct())
                .Where(product => product.GetId() == _Id)
                .FirstOrDefault();
        }

        public Product InsertOne(Product _Product)
        {
            Product NewProduct = Product.BuildProduct(
                _Product.Title,
                _Product.Description,
                _Product.ImageUrl,
                _Product.Price
            );

            Products.Add(NewProduct);
            return NewProduct;
        }

        public bool RemoveOne(Product Product)
        {
            return Products.Remove(Product);
        }

        public Product UpdateOne(Product _Product, long _Id)
        {
            Product Product = FindById(_Id);
            Product.Title = _Product.Title;
            Product.Description = _Product.Description;
            Product.ImageUrl = _Product.ImageUrl;
            Product.Price = _Product.Price;
            return Product;
        }
    }
}
