using Kart.WebStore.Domain;

namespace Kart.WebStore.Infrastructure
{
    public interface IOrderRepo
    {
        /// <summary>
        /// Get the Order by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Order> GetAsync(string id);
        /// <summary>
        /// Update the Order by Order object
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        Task<Order> UpdateAsync(Order order);
        /// <summary>
        /// Delete the order by Its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task DeleteAsync(string id);

        /// <summary>
        /// Create the order by order object
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> CreateAsync(Order order);

        /// <summary>
        /// GetAllOrders
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetAllAsync();
    }
}
