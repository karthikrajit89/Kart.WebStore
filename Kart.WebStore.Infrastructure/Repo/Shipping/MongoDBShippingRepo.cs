using Kart.WebStore.Domain;
using Kart.WebStore.Infrastructure.Repo.Shipping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Kart.WebStore.Infrastructure
{
    internal class MongoDBShippingRepo : IShippingRepo
    {
        private readonly IMongoCollection<ShippingRecord> _shippingCollection;
        private readonly MongoClient _mongoClient;
        private readonly WebStoreParams _webStoreParams;
        private readonly IMongoDatabase _imongoDatabase;
       
        public MongoDBShippingRepo(IConfiguration configuraiton) : this(configuraiton.Get<WebStoreParams>())
        {

        }
        internal MongoDBShippingRepo(WebStoreParams webstoreParams)
        {
            _webStoreParams = webstoreParams;
            _mongoClient = new MongoClient(_webStoreParams.DBConnectionString);
            _imongoDatabase = _mongoClient.GetDatabase(_webStoreParams.DBName);
            _shippingCollection = _imongoDatabase.GetCollection<ShippingRecord>(_webStoreParams.ShippingCollectionName);

        }
        public async Task CreateAsync(Shippers shippers)
        {
            if(shippers.Id == Guid.Empty || shippers.Id is null )
                shippers.Id = Guid.NewGuid();
            await _shippingCollection.InsertOneAsync(shippers.FromModel());
            
        }

        public async Task DeleteAsync(string id)
        {
            await _shippingCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Shippers> GetAsync(string id)
        {
            var shipping = await _shippingCollection.FindAsync(x => x.Id == id);
            return shipping.FirstOrDefaultAsync().Result?.ToModel();
        }

        public async Task<Shippers> UpdateAsync(Shippers shippers)
        {
            var idtoUpdate = shippers.Id.ToString();
            ShippingRecord shippingRecord = shippers.FromModel();
            await _shippingCollection.ReplaceOneAsync(x => x.Id == idtoUpdate, shippingRecord);
            return GetAsync(idtoUpdate).Result;
        }

        public async Task<List<Shippers>> GetAllAsync()
        {
            var shippingCollection = _imongoDatabase.GetCollection<ShippingRecord>(_webStoreParams.ShippingCollectionName);
            var shippingDocuments = await shippingCollection.FindAsync(_ => true).Result.ToListAsync();

            var shippinglist = new List<Shippers>();

            foreach (var shipping in shippingDocuments)
            {
                shippinglist.Add(shipping.ToModel());
            }
            return shippinglist;
        }
    }
}
