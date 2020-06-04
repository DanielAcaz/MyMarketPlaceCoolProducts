using System;
namespace MyMarketPlaceCoolProducts.Model
{
    public class Product
    {

        private static long _Id = 0;

        public Product()
        {
        }

        public Product(string title, string description, string imageUrl, double price)
        {
            Id = ++_Id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public long GetId()
        {
            return Id;
        }

    }
}
