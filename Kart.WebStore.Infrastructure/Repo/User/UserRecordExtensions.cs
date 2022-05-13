using Kart.WebStore.Domain.Util;
using Kart.WebStore.Domain;
using Kart.WebStore.Infrastructure.Repo.User;
namespace Kart.WebStore.Infrastructure
{
    static internal class UserRecordExtensions
    {

        public static UserRecord FromModel(this User user)
        {
            var  record = new UserRecord();
            record.UserId = user.Id != null ? user.Id.ToString() : String.Empty;
            record.UserName = user.Name;
            record.Email = user.Email;
            record.UserPassword = user.Password;
            record.Admin = user.Admin;
            return record;
        }

        public static User ToModel(this UserRecord record)
        {
            var user = new User();
            user.Id = Guid.Parse(record.UserId);
            user.Name = record.UserName;  
            user.Email = record.Email;
            user.Password = record.UserPassword;
            user.Admin = record.Admin;  
            return user;

        }
    }
}
