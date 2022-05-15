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

      
        [BsonElement(OrderTableScheme.ShipmentId)]
        public string? ShipmentId { get; set; } 

        [BsonElement(OrderTableScheme.TotalPrice)]
        public decimal TotalPrice { get; set; }

        public List<CartFinalRecord> CartFinalRecords { get; set; }

        [BsonElement(OrderTableScheme.UserId)]
        public string UserId { get; set; }

        [BsonElement(OrderTableScheme.ShippingAddress)]
        public string ShippingAddress { get; set; }

        [BsonElement(OrderTableScheme.ShippingPrice)]   
        public decimal ShippingPrice { get; set; }

        
    }

    public class CartFinalRecord
    {
        [BsonElement(OrderTableScheme.ProductId)]
        public string ProductId { get; set; }

        [BsonElement(OrderTableScheme.Qty)]
        public int Qty { get; set; }
    }
}
