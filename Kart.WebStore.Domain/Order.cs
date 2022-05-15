namespace Kart.WebStore.Domain
{
    public class Order
    {
        public Guid? Id { get; set; }
        public List<CartFinal> CartFinalList { get; set; }
        public Guid? ShipmentId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingPrice { get; set; }
        public string ShippingAddress { get; set; }
        public Guid? UserId { get; set; }
    }

    public class CartFinal
    {
        public string ProductId { get; set; }
        
        public int Qty { get; set; }
    }
}
