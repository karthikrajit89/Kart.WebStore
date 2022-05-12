namespace Kart.WebStore.Domain
{
    public class Order
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid? ShipmentId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
