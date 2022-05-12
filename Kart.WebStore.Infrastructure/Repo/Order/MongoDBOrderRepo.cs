using Kart.WebStore.Domain;
using Kart.WebStore.Infrastructure.Repo.Order;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Kart.WebStore.Infrastructure
{
   
    internal class MongoDBOrderRepo : IOrderRepo
    {
        private readonly IMongoCollection<OrderRecord> _orderCollection;
        private readonly MongoClient _mongoClient;
        private readonly WebStoreParams _webStoreParams;
        private readonly IMongoDatabase _imongoDatabase;
        

        public MongoDBOrderRepo(IConfiguration configuraiton) : this(configuraiton.Get<WebStoreParams>())
        {
            
        }
        internal MongoDBOrderRepo (WebStoreParams webstoreParams)
        {
            _webStoreParams = webstoreParams;
            _mongoClient = new MongoClient (_webStoreParams.DBConnectionString);
            _imongoDatabase = _mongoClient.GetDatabase(_webStoreParams.DBName);
            _orderCollection = _imongoDatabase.GetCollection<OrderRecord>(_webStoreParams.OrderCollectionName);

        }

        public async Task<Order> CreateAsync(Order order)
        {
            if(order.Id == Guid.Empty || order.Id is null)
                order.Id = Guid.NewGuid();
            if(order.ShipmentId == Guid.Empty || order.ShipmentId is null)  
                order.ShipmentId = Guid.NewGuid();
            await _orderCollection.InsertOneAsync(order.FromModel());

            return order;
        }

        public async Task DeleteAsync(string id)
        {
          await _orderCollection.DeleteOneAsync( x => x.Id == id);
        }

        public async Task<Order> GetAsync(string id)
        {
            var order = await _orderCollection.FindAsync(x => x.Id == id);
            return order.FirstOrDefaultAsync().Result?.ToModel();
            
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            var idtoUpdate = order.Id.ToString();
            OrderRecord orderRecord = order.FromModel();
            await _orderCollection.ReplaceOneAsync(x => x.Id == idtoUpdate, orderRecord);
            return GetAsync(idtoUpdate).Result;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orderCollection = _imongoDatabase.GetCollection<OrderRecord>(_webStoreParams.OrderCollectionName);
            var orderDocuments = await orderCollection.FindAsync(_ => true).Result.ToListAsync();

            var orderList = new List<Order>();

            foreach (var order in orderDocuments)
            {
                orderList.Add(order.ToModel());
            }
            return orderList;
        }
    }
}
