using System;
namespace MyMarketPlaceCoolProducts.Model
{
    public class Product
    {

        private static long _Id = 0;

        public Product()
        {
        }

        private Product(string title, string description, string imageUrl, double price)
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

        public virtual long GetId()
        {
            return Id;
        }

        public static Product BuildProduct(string Title,
            string Description, string ImageUrl, double Price)
        {

            if(string.IsNullOrEmpty(Title) ||
                string.IsNullOrEmpty(Description) ||
                string.IsNullOrEmpty(ImageUrl) ||
                double.IsNaN(Price))
            {
                return new EmptyProduct();
            }

            return new Product(Title, Description, ImageUrl, Price);
        }

        public class EmptyProduct : Product
        {
            internal EmptyProduct() :
                base(string.Empty, string.Empty, string.Empty, 0)
            {

            }

            public override long GetId()
            {
                return 0;
            }
        }

    }
}
