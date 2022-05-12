using Kart.WebStore.Domain;

namespace Kart.WebStore.Services.Services
{
    public interface IProductServices
    {
        /// <summary>
        /// Get Product by its ID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> GetProductAsync(Guid productId);

        /// <summary>
        /// Update the Product using Product object
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> UpdateProductAsync(Product product);
        /// <summary>
        /// Delete the product by its Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task DeleteProductAsync(Guid productId);
        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task CreateProductAsync(Product product);

        /// <summary>
        /// GetAll Products 
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllProductsAsync();


    }
}
