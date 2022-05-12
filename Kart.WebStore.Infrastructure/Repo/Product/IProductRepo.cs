using Kart.WebStore.Domain;

namespace Kart.WebStore.Infrastructure
{
    public interface IProductRepo
    {
        /// <summary>
        /// Get The Product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetAsync(string id);
        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task CreateAsync(Product product);
        /// <summary>
        /// Update the Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> UpdateAsync(Product product);
        /// <summary>
        /// Delete the product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// GetAllProducts 
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllAsync();

     

    }
}
