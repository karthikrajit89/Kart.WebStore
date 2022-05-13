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
            record.CartFinalRecords = new List<CartFinalRecord>();
            
            foreach(CartFinal rec in order.CartFinalList)
            {
                var finalRec = new CartFinalRecord { ProductId = rec.ProductId.ToString(), Qty = rec.Qty};
                record.CartFinalRecords.Add(finalRec);
            }
            record.ShipmentId = order.ShipmentId !=null ? order.ShipmentId.ToString() : string.Empty;
            record.Id = order.Id !=null ? order.Id.ToString() : string.Empty;
            record.TotalPrice = order.TotalPrice;
            record.UserId = order.UserId !=null ? order.UserId.ToString() : string.Empty;
            return record;

        }

        public static Order ToModel (this OrderRecord data)
        {
            var order = new Order();
            order.CartFinalList = new List<CartFinal>();

            foreach (CartFinalRecord rec in data.CartFinalRecords)
            {
                var finalRec = new CartFinal { ProductId = rec.ProductId, Qty = rec.Qty };
                order.CartFinalList.Add(finalRec);
            }
           
            order.ShipmentId = Guid.Parse(data.ShipmentId);
            order.Id = Guid.Parse(data.Id);
            order.TotalPrice = data.TotalPrice;
            
            order.UserId = Guid.Parse(data.UserId);
            return order;
        }
    }
}
