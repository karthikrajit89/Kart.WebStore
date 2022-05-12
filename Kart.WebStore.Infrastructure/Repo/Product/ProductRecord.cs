using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kart.WebStore.Infrastructure.Repo.Product
{
     class ProductRecord
    {
        public ProductRecord() 
        { 
        }

        [BsonId]
        [BsonElement(ProductTableScheme.Id)]
        public string? Id { get; set; }

        [BsonElement(ProductTableScheme.ProductName)]
        public string ProductName { get; set; }

        [BsonElement(ProductTableScheme.ProductType)]
        public int ProductType { get; set; }

        [BsonElement(ProductTableScheme.Brand)]
        public int Brand { get; set; }

        [BsonElement(ProductTableScheme.Price)]
        public decimal Price { get; set; }

        [BsonElement(ProductTableScheme.NewCollection)]
        public bool NewCollection { get; set; }

        [BsonElement(ProductTableScheme.DiscountPercent)]
        public int DiscountPercent { get; set; }

        [BsonElement(ProductTableScheme.ImageUrl)]
        public string ImageUrl { get; set; }    

    }
}
