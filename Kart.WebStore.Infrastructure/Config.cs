namespace Kart.WebStore.Infrastructure
{
    public class Configs
    {
        public string OrderDocumentLink { get; set; }

        public string ShippDocumentLink { get; set; }

        public string ProductsDocumentLink { get; set; }

    }

    public class S3Option
    {
        public string BucketName { get; set; }
        public string Folder { get; set; }
    }
}