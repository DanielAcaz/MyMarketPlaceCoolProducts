using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMarketPlaceCoolProducts.Models
{
    public class Product
    {

        public Product()
        {
        }

        private Product(string title, string description, string imageUrl, double price)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
        }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

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
        }

    }
}
