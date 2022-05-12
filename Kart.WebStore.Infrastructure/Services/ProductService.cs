
using Kart.WebStore.Domain;
using Kart.WebStore.Services.Services;
using Microsoft.Extensions.Options;

namespace Kart.WebStore.Infrastructure.Services
{
    internal class ProductService : IProductServices
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo shippingRepo)
        {
            _productRepo = shippingRepo;
        }

        public async Task CreateProductAsync(Product product)
        {
            if (product != null)
                await _productRepo.CreateAsync(product);
            else
                throw new InvalidDataException("Shipping object should not be null");
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new InvalidDataException(nameof(productId));
            else
                await _productRepo.DeleteAsync(productId.ToString());
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new InvalidDataException(nameof(productId));
            else
                return await _productRepo.GetAsync(productId.ToString());
        }

        public  async Task<Product> UpdateProductAsync(Product product)
        {
            if (product == null)
                throw new InvalidDataException(nameof(product));
            else
                return await _productRepo.UpdateAsync(product);
        }


        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepo.GetAllAsync();
        }

    }
}
