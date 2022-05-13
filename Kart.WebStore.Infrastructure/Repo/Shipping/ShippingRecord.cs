using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kart.WebStore.Infrastructure.Repo.Shipping
{
    class ShippingRecord
    {
        public ShippingRecord()
        {

        }

        [BsonId]
        [BsonElement(ShippingTableScheme.ShippingId)]
        public string? Id { get; set; }

        [BsonElement(ShippingTableScheme.ShippingMode)]
        public string ShippingMode { get; set; }

        [BsonElement(ShippingTableScheme.ShippingType)]
        public string ShippingType { get; set; }

        [BsonElement(ShippingTableScheme.ShippingPrice)]
        public decimal ShippingPrice { get; set; }

        [BsonElement(ShippingTableScheme.ShippingAddress)]
        public string ShippingAddress { get; set; }

    }
}
