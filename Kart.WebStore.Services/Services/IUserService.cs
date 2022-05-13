using Kart.WebStore.Domain;

namespace Kart.WebStore.Services.Services
{
    public interface  IUserService
    {
        /// <summary>
      /// Get the Order by Id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        Task<User> GetAsync(string emailId);

        /// <summary>
        /// Create User Profile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> CreateAsync(User user);
    }
}
