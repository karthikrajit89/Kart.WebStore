using Kart.WebStore.Domain.Util;
using Kart.WebStore.Domain;
using Kart.WebStore.Infrastructure.Repo.Product;

namespace Kart.WebStore.Infrastructure
{
    internal static class ProductRecordExtension
    {
        public static ProductRecord FromModel (this Product product)
        {
            var productRecord = new ProductRecord ();
            productRecord.Id = product.Id!=null ? product.Id.ToString() : String.Empty;
            productRecord.ProductName = product.Name;
            productRecord.ProductType = (int)product.ProductType;
            productRecord.Brand = (int)product.Brand;
            productRecord.Price = product.Price;
            productRecord.NewCollection = product.NewCollection;
            productRecord.DiscountPercent = product.DiscountPercent;
            productRecord.ImageUrl = product.ImageUrl;
            productRecord.Description = product.Description;    
            return productRecord;

        }

        public static Product ToModel(this ProductRecord data)
        {
            var model = new Product();
            model.Id = Guid.Parse(data.Id);
            model.Name = data.ProductName;
            model.ProductType = (ProductType) data.ProductType;
            model.Brand = (Brand) data.Brand;
            model.Price = data.Price;   
            model.NewCollection = data.NewCollection;
            model.DiscountPercent = data.DiscountPercent;
            model.ImageUrl = data.ImageUrl;
            model.Description = data.Description;       
            return model;   
        }
    }
}
