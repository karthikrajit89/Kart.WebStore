
using Kart.WebStore.Domain;
using Kart.WebStore.Services.Services;
using Microsoft.Extensions.Options;

namespace Kart.WebStore.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        

        public UserService (IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

      

        public Task<User> CreateAsync(User user)
        {
            if(user == null)
                throw new InvalidDataException("user object should not be null");

            return _userRepo.CreateAsync(user);
        }

        public Task<User> GetAsync(string emailId)
        {
            if (string.IsNullOrEmpty(emailId))
                throw new InvalidDataException("emailId should not be empty");

            return _userRepo.GetAsync(emailId);
            
        }
    }
}
