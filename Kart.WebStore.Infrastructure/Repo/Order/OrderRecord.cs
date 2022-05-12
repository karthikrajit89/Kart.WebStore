using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Kart.WebStore.Infrastructure.Repo.Order
{
     class OrderRecord
    {
        public OrderRecord()
        {

        }

        [BsonId]
        [BsonElement(OrderTableScheme.Id)]
        public string? Id { get; set; }

        [BsonElement(OrderTableScheme.ProductId)]
        public string ProductId { get; set; }

        [BsonElement(OrderTableScheme.ShipmentId)]
        public string? ShipmentId { get; set; } 

        [BsonElement(OrderTableScheme.TotalPrice)]
        public decimal TotalPrice { get; set; }

        [BsonElement(OrderTableScheme.Quantity)]
        public int Quantity { get; set; }
        


    }
}
