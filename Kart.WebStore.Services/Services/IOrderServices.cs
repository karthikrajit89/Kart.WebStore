using Kart.WebStore.Domain;

namespace Kart.WebStore.Services.Services
{
    public interface IOrderServices
    {
        /// <summary>
        /// Get Order by its ID
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> GetOrderAsync(Guid orderId);

        /// <summary>
        /// Update the Order using Order object
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> UpdateOrderAsync(Order order);
        /// <summary>
        /// Delete the order by its Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task DeleteOrderAsync(Guid orderId);
        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> CreateOrderAsync(Order order);


        /// <summary>
        /// GetAllOrders
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetAllOrdersAsync();
    }
}
