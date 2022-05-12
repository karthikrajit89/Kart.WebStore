using Kart.WebStore.Domain;
using Kart.WebStore.Infrastructure.Repo.Product;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Kart.WebStore.Infrastructure
{
    internal class MongoDBProductRepo : IProductRepo
    {
        private readonly IMongoCollection<ProductRecord> _productCollection;
        private readonly MongoClient _mongoClient;
        private readonly WebStoreParams _webStoreParams;
        private readonly IMongoDatabase _imongoDatabase;
      
         public MongoDBProductRepo(IConfiguration configuraiton) : this(configuraiton.Get<WebStoreParams>())
        {
            
        }
        internal MongoDBProductRepo(WebStoreParams webStoreParams)
        {
            _webStoreParams = webStoreParams;
            _mongoClient = new MongoClient(_webStoreParams.DBConnectionString);
            _imongoDatabase = _mongoClient.GetDatabase(_webStoreParams.DBName);
            _productCollection = _imongoDatabase.GetCollection<ProductRecord>(_webStoreParams.ProductCollectionName);

        }

        public async Task CreateAsync(Product product)
        {
            if(product.Id == Guid.Empty || product.Id is null)
                product.Id = Guid.NewGuid();
            await _productCollection.InsertOneAsync(product.FromModel());
        }

        public async Task DeleteAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Product> GetAsync(string id)
        {
            var product = await _productCollection.FindAsync(x => x.Id == id);
            return product.FirstOrDefaultAsync().Result?.ToModel();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var idtoUpdate = product.Id.ToString();
            ProductRecord productRecord = product.FromModel();
            await _productCollection.ReplaceOneAsync(x => x.Id == idtoUpdate, productRecord);
            return GetAsync(idtoUpdate).Result;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var productCollection =  _imongoDatabase.GetCollection<ProductRecord>(_webStoreParams.ProductCollectionName);
            var productDocuments = await productCollection.FindAsync(_=>true).Result.ToListAsync();

            var productsList = new List<Product>();

            foreach (var product in productDocuments)
            {
                productsList.Add(product.ToModel());
            }
            return productsList;
        }
    }
}
