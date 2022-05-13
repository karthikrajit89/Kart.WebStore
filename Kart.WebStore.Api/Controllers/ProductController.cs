using Microsoft.AspNetCore.Mvc;
using Kart.WebStore.Services.Services;
using Kart.WebStore.Domain;
using Swashbuckle.AspNetCore.Annotations;

namespace Kart.WebStore.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productService)
        {
            _productServices = productService;
        }

       

        [HttpGet]
        [Route("kartWebstore/GetProduct/{id}")]
        [SwaggerResponse(200, Type = typeof(Product))]
        [SwaggerResponse(500, "Something went wrong internally")]
       
        public async Task<ActionResult<Product>> Get([FromRoute] Guid? id)
        {
            if (id == Guid.Empty || id is null)
                throw new InvalidDataException("id not specified");
            var product = await _productServices.GetProductAsync(id.Value);
            if (product == null)
                return NotFound("Product with the Id not found");
            return Ok(product);
        }


        [HttpPost]
        [Route("kartWebStore/CreateProduct")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult> Create([FromBody] Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            await _productServices.CreateProductAsync(product);
            return Ok();
        }

        [HttpPut]
        [Route("kartWebStore/UpdateProduct")]
        [SwaggerResponse(200, Type = typeof(Product))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<Product>> Update([FromBody] Product product)
        {

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return await _productServices.UpdateProductAsync(product);
        }

        [HttpDelete]
        [Route("kartWebStore/DeleteProduct/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async void Delete([FromRoute] Guid? id)
        {
            if (id == Guid.Empty || id is null )
                throw new InvalidDataException("id not specified");
            await _productServices.DeleteProductAsync(id.Value);
        }


        [HttpGet]
        [Route("kartWebStore/GetAllProducts")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<Product>))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await _productServices.GetAllProductsAsync();
        }

        [HttpGet]
        [Route("kartWebStore/GetCollectionById/{id}")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<Product>))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<List<Product>>> GetAllById([FromRoute]Guid? id)
        {
            if(id == Guid.Empty || id is null )
                throw new InvalidDataException("id not specified");
            var products = await _productServices.GetAllProductsAsync();

            List<Product> productCollection = new List<Product>();

            productCollection.AddRange(products.Where(x => x.Id == id));

            return productCollection;

        }
    }
}
