
using Kart.WebStore.Domain;
using Kart.WebStore.Services.Services;
using Microsoft.Extensions.Options;

namespace Kart.WebStore.Infrastructure.Services
{
    internal class ShippingService : IShippingServices
    {
        private readonly IShippingRepo _shippingRepo;
        
        public ShippingService (IOptions<WebStoreParams> options,
            IShippingRepo shippingRepo)
        {
            _shippingRepo = shippingRepo;
        }

        public async Task  CreateShippersAsync(Shippers shipper)
        {
            if (shipper != null)
                await _shippingRepo.CreateAsync(shipper);
            else
                throw new InvalidDataException("Shipping object should not be null");
        }

        public async Task DeleteShippersAsync(Guid shippingId)
        {
            if (shippingId == Guid.Empty)
                throw new InvalidDataException(nameof(shippingId));
            else
                await _shippingRepo.DeleteAsync(shippingId.ToString());
        }


        public async Task<Shippers> GetShippersAsync(Guid shipperId)
        {
            if(shipperId == Guid.Empty)
                throw  new InvalidDataException(nameof(shipperId));
            else
                return await _shippingRepo.GetAsync(shipperId.ToString());
        }

        public async Task<Shippers> UpdateShippersAsync(Shippers shipper)
        {
           if(shipper==null)
                throw new InvalidDataException(nameof(shipper));
           else 
                return await  _shippingRepo.UpdateAsync(shipper);
        }


        public async Task<List<Shippers>> GetAllShippersAsync()
        {
            return await _shippingRepo.GetAllAsync();   
        }
    }
}
