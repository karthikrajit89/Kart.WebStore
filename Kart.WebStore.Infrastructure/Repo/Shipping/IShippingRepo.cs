using Kart.WebStore.Domain;

namespace Kart.WebStore.Infrastructure
{
    public interface IShippingRepo
    {
        /// <summary>
        /// Get the Shipping object using Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Shippers> GetAsync(string Id);
        
        /// <summary>
        /// Update the Shipping Object
        /// </summary>
        /// <param name="shippers"></param>
        /// <returns></returns>
        Task<Shippers> UpdateAsync(Shippers shippers);

        /// <summary>
        /// Delete the shipping by its ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task DeleteAsync(string Id);

        /// <summary>
        /// Create the shipping
        /// </summary>
        /// <param name="shippers"></param>
        /// <returns></returns>
        Task CreateAsync(Shippers shippers);

        /// <summary>
        /// GetAllShippings
        /// </summary>
        /// <returns></returns>
        Task<List<Shippers>> GetAllAsync();

    }
}
