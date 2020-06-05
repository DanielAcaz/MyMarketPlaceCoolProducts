using System;
using System.Collections.Generic;
using MyMarketPlaceCoolProducts.DTO;
using MyMarketPlaceCoolProducts.Models;

namespace MyMarketPlaceCoolProducts.Creationals
{
    public class ProductFactory : IFactory<Product, ProductDTO>
    {
        public ProductFactory()
        {
        }

        public Product Create(ProductDTO dto)
        {
            return BuildProduct(dto);
        }

        public IList<Product> Create(IList<ProductDTO> dtos) =>
            new List<ProductDTO>(dtos).ConvertAll(dto => BuildProduct(dto));


        private static Product BuildProduct(ProductDTO dto) =>
            new BuilderProduct()
                .Title(dto.Title)
                .Description(dto.Description)
                .ImageUrl(dto.ImageUrl)
                .Price(dto.Price)
                .Build();

        private bool ProductIsInvalid(Product product) =>
                string.IsNullOrEmpty(product.Title) ||
                string.IsNullOrEmpty(product.Description) ||
                string.IsNullOrEmpty(product.ImageUrl) ||
                double.IsNaN(product.Price);

        public ProductDTO Create(Product product)
        {
            var productWillCreate = product ?? new Product();
            if (ProductIsInvalid(productWillCreate))
                return new EmptyProduct();
            ProductDTO productDTO = new ProductDTO(product.Title, product.Description,
                            product.ImageUrl, product.Price);
            productDTO.Id = product.Id ?? string.Empty;
            return productDTO;
        }

        public IList<ProductDTO> Create(IList<Product> products) =>
            new List<Product>(products).ConvertAll(product => Create(product));

        public class EmptyProduct : ProductDTO
        {
            internal EmptyProduct() :
                base(string.Empty, string.Empty, string.Empty, 0)
            {

            }
        }
    }
}
