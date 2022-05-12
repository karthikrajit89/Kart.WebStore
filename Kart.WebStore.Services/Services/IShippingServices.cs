using Kart.WebStore.Domain;

namespace Kart.WebStore.Services.Services
{
    public interface IShippingServices
    {/// <summary>
     /// Get Shipper by its ID
     /// </summary>
     /// <param name="shipperId"></param>
     /// <returns></returns>
        Task<Shippers> GetShippersAsync(Guid shipperId);

        /// <summary>
        /// Update the Shippers using Shippers object
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        Task<Shippers> UpdateShippersAsync(Shippers shipper);
        /// <summary>
        /// Delete the shipping by its Id
        /// </summary>
        /// <param name="shippingId"></param>
        /// <returns></returns>
        Task DeleteShippersAsync(Guid shippingId);
        /// <summary>
        /// Create a new shipper
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        Task CreateShippersAsync(Shippers shipper);

        /// <summary>
        /// GetAll Shippings
        /// </summary>
        /// <returns></returns>
        Task<List<Shippers>> GetAllShippersAsync();
    }
}
