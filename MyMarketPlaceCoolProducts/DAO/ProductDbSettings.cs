using System;
namespace MyMarketPlaceCoolProducts.DAO
{
    public class ProductDbSettings : IProductDbSettings
    {
        public ProductDbSettings()
        {
        }

        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductDbSettings
    {
        string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
