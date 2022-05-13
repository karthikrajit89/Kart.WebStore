using Kart.WebStore.Domain;
using Kart.WebStore.Infrastructure.Repo.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Kart.WebStore.Infrastructure
{
    internal class MongoDBUserRepo :IUserRepo
    {

        private readonly IMongoCollection<UserRecord> _userCollection;
        private readonly MongoClient _mongoClient;
        private readonly WebStoreParams _webStoreParams;
        private readonly IMongoDatabase _imongoDatabase;


        public MongoDBUserRepo(IConfiguration configuraiton) : this(configuraiton.Get<WebStoreParams>())
        {

        }
        internal MongoDBUserRepo(WebStoreParams webstoreParams)
        {
            _webStoreParams = webstoreParams;
            _mongoClient = new MongoClient(_webStoreParams.DBConnectionString);
            _imongoDatabase = _mongoClient.GetDatabase(_webStoreParams.DBName);
            _userCollection = _imongoDatabase.GetCollection<UserRecord>(_webStoreParams.UserCollectionName);

        }

        public async Task<User> CreateAsync(User user)
        {
            if (user.Id == Guid.Empty || user.Id is null)
                user.Id = Guid.NewGuid();

             user.Admin = true; //I made all users are admin for this kartWebStore  demo purpose only

             await _userCollection.InsertOneAsync(user.FromModel());

            return user;
        }

        public async Task<User> GetAsync(string emailId)
        {
            var user = await _userCollection.FindAsync(x => x.Email == emailId);
            return user.FirstOrDefaultAsync().Result?.ToModel();
        }
    }
}
