

namespace Kart.WebStore.Domain
{
    public class Shippers
    {
        public Guid? Id { get; set; }
        public string Mode { get; set; } = null!;
        public string ShippingType { get; set; } = null!;
        public decimal ShippingPrice { get; set; }
        public string ShippingAddress { get; set; } = null!;

    }
}
