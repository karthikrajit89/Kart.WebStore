
using Kart.WebStore.Domain;

namespace Kart.WebStore.Infrastructure.Repo.Shipping
{
    internal static class ShippingRecordExtension
    {
        public static ShippingRecord FromModel(this Shippers shippers)
        {
            var shippingRecord = new ShippingRecord();
            shippingRecord.Id = shippers.Id != null ? shippers.Id.ToString() : string.Empty;
            shippingRecord.ShippingMode = shippers.Mode;
            shippingRecord.ShippingType = shippers.ShippingType;
            shippingRecord.ShippingPrice = shippers.ShippingPrice;
            return shippingRecord;
        }

        public static Shippers ToModel(this ShippingRecord data)
        {
            var shippers = new Shippers();
            shippers.Id = Guid.Parse(data.Id);
            shippers.ShippingType = data.ShippingType;
            shippers.Mode = data.ShippingMode;
            shippers.ShippingPrice = data.ShippingPrice;
            return shippers;
        }
    }
}
