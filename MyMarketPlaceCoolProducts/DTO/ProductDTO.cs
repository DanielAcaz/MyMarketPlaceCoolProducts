using System;
namespace MyMarketPlaceCoolProducts.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
        }

        public ProductDTO(string title, string description, string imageUrl, double price)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }
    }
}
