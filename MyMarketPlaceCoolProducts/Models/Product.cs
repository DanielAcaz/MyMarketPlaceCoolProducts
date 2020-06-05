using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMarketPlaceCoolProducts.Models
{
    public class Product
    {

        public Product()
        {
            Secret = "SECRET" + DateTime.Now.ToString("yyyyMMddHHmmssffff")
                + new Random().Next(1, 1000);
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        [BsonRequired()]
        public string Title { get; set; }

        [BsonElement("description")]
        [BsonRequired()]
        public string Description { get; set; }

        [BsonElement("imageUrl")]
        [BsonRequired()]
        public string ImageUrl { get; set; }

        [BsonElement("price")]
        [BsonRequired()]
        public double Price { get; set; }

        [BsonElement("secret")]
        public string Secret { get;}
    }
}
