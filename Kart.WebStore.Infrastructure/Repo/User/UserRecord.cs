using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kart.WebStore.Infrastructure.Repo.User
{
     class UserRecord
    {
        public UserRecord()
        {
        }

        [BsonId]
        [BsonElement(UserTableScheme.UserId)]
        public string? UserId { get; set; }

        [BsonElement(UserTableScheme.UserName)]
        public string UserName { get; set; }

        [BsonElement(UserTableScheme.UserPassword)]
        public string UserPassword { get; set; }

        [BsonElement(UserTableScheme.Email)]
        public string Email { get; set; }

        [BsonElement(UserTableScheme.Admin)]
        public bool Admin { get; set; }


    }
}
