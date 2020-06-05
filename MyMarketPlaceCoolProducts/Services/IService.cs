using System.Collections.Generic;
using MyMarketPlaceCoolProducts.DTO;

namespace MyMarketPlaceCoolProducts.Services
{
    public interface IService
    {
        IEnumerable<ProductDTO> GetProducts();

        ProductDTO DeleteById(string _Id);

        ProductDTO CreateProduct(ProductDTO _Product);

        ProductDTO GetById(string _Id);

        ProductDTO UpdateProduct(ProductDTO Product, string Id);
    }
}
