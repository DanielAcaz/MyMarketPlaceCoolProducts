using System.Collections.Generic;
using MyMarketPlaceCoolProducts.Creationals;
using MyMarketPlaceCoolProducts.DTO;
using MyMarketPlaceCoolProducts.Error;
using MyMarketPlaceCoolProducts.Models;
using MyMarketPlaceCoolProducts.Repositories;
using static MyMarketPlaceCoolProducts.Creationals.ProductFactory;

namespace MyMarketPlaceCoolProducts.Services
{
    public class ProductService : IService
    {

        private readonly IRepository<Product, string> _repository;
        private readonly IFactory<Product, ProductDTO> _factory; 

        public ProductService(IRepository<Product, string> repository, IFactory<Product, ProductDTO> factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _factory.Create(_repository.FindAll());
        }

        public ProductDTO DeleteById(string id)
        {
            Product product = _repository.FindById(id);
            ProductDTO productDTO = _factory.Create(product);
            if (productDTO is EmptyProduct)
                throw new InvalidProductException("This product is invalid!");
            if (_repository.RemoveOne(product))
            {
                return productDTO;
            }
            throw new InvalidProductException("Cannot remove this Product");


        }

        public ProductDTO CreateProduct(ProductDTO productDTO)
        {
            Product newProduct = _repository
                .InsertOne(_factory.Create(productDTO));

            ProductDTO newProductDTO = _factory.Create(newProduct);
            if (newProductDTO is EmptyProduct)
                throw new InvalidProductException("Cannot create this Product");
            return newProductDTO;
        }

        public ProductDTO GetById(string id)
        {
            ProductDTO productDTO = _factory
                .Create(_repository.FindById(id));

            if(productDTO is EmptyProduct)
                throw new InvalidProductException("Cannot found this Product");
            return productDTO;
        }

        public ProductDTO UpdateProduct(ProductDTO productDTO, string id)
        {
            Product product = _repository.FindById(id);
            ProductDTO productDTOUpdate = _factory.Create(product);
            if (productDTOUpdate is EmptyProduct)
                throw new InvalidProductException("This product is invalid!");

            product.Title = productDTO.Title;
            product.ImageUrl = productDTO.ImageUrl;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;

            Product productUpdated = _repository.UpdateOne(product, id);

            ProductDTO productDTOUpdated = _factory.Create(productUpdated);
            if (productDTOUpdated is EmptyProduct)
                throw new InvalidProductException("This product is invalid!");

            return productDTOUpdated;
        }
    }
}
