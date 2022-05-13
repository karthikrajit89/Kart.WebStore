using Kart.WebStore.Domain;

namespace Kart.WebStore.Infrastructure
{
    public interface IUserRepo
    {
        /// <summary>
        /// Get the User by EmailId
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
