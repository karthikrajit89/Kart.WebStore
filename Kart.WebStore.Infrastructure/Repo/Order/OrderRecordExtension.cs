using Kart.WebStore.Domain.Util;
using Kart.WebStore.Domain;
using Kart.WebStore.Infrastructure.Repo.Order;
namespace Kart.WebStore.Infrastructure
{
    static internal class OrderRecordExtension
    {

        public static OrderRecord FromModel(this Order order)
        {
            OrderRecord record = new OrderRecord();
            record.ProductId = order.ProductId !=null ? order.ProductId.ToString() : string.Empty;
            record.ShipmentId = order.ShipmentId !=null ? order.ShipmentId.ToString() : string.Empty;
            record.Id = order.Id !=null ? order.Id.ToString() : string.Empty;
            record.TotalPrice = order.TotalPrice;
            record.Quantity = order.Quantity;
            return record;

        }

        public static Order ToModel (this OrderRecord data)
        {
            var order = new Order();
            order.ProductId = Guid.Parse(data.ProductId);
            order.ShipmentId = Guid.Parse(data.ShipmentId);
            order.Id = Guid.Parse(data.Id);
            order.TotalPrice = data.TotalPrice;
            order.Quantity = data.Quantity;
            return order;
        }
    }
}
