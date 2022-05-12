namespace Kart.WebStore.Infrastructure
{
    public class WebStoreParams
    {
        public string DBConnectionString { get; set; } = null!;
        public string DBName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
        public string OrderCollectionName { get; set; } = null!;
        public string ShippingCollectionName { get; set; } = null!;


    }

    public class S3Option
    {
        public string BucketName { get; set; }
        public string Folder { get; set; }
    }
}