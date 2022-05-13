
using Kart.WebStore.Domain;
using Kart.WebStore.Services.Services;
using Microsoft.Extensions.Options;

namespace Kart.WebStore.Infrastructure.Services
{
    internal class OrderService : IOrderServices
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order != null)
               return  await _orderRepo.CreateAsync(order);
            else
                throw new InvalidDataException("Shipping object should not be null");
        }

        public async Task DeleteOrderAsync(Guid orderId)
        {

            if (orderId == Guid.Empty)
                throw new InvalidDataException(nameof(orderId));
            else
                await _orderRepo.DeleteAsync(orderId.ToString());
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {

            if (orderId == Guid.Empty)
                throw new InvalidDataException(nameof(orderId));
            else
                return await _orderRepo.GetAsync(orderId.ToString());
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if (order == null)
                throw new InvalidDataException(nameof(order));
            else
                return await _orderRepo.UpdateAsync(order);
        }


        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepo.GetAllAsync();
        }
    }
}
