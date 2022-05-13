using Kart.WebStore.Domain.Util;

namespace Kart.WebStore.Domain
{
    public class Product
    {
        public Guid? Id { get; set; } 
        public string Name { get; set; } = null!;
        public ProductType ProductType {get;set;}
        public Brand Brand { get; set; }
        public decimal Price { get; set; }
        public bool NewCollection { get; set; }
        public int DiscountPercent { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }



    }
}