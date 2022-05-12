using Microsoft.AspNetCore.Mvc;
using Kart.WebStore.Services.Services;
using Kart.WebStore.Domain;
using Swashbuckle.AspNetCore.Annotations;

namespace Kart.WebStore.Api.Controllers
{
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingServices _shippingServices;

        public ShippingController(IShippingServices shippingServices)
        {
            _shippingServices = shippingServices;
        }

        [HttpGet]
        [Route("kartWebstore/GetShipping/{id}")]
        [SwaggerResponse(200, Type = typeof(Shippers))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<Shippers>> Get([FromRoute] Guid? id)
        {
            if (id == Guid.Empty || id is  null)
                throw new InvalidDataException("id not specified");
            var shippers = await _shippingServices.GetShippersAsync(id.Value);
            if(shippers == null)
                return NotFound("Shipping with the Id not found");
            return Ok(shippers);
        }

        [HttpPost]
        [Route("kartWebStore/CreateShipping")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult> Create([FromBody] Shippers shipper)
        {
            if (shipper == null)
                throw new ArgumentNullException(nameof(shipper));
            if (shipper.Id == Guid.Empty || shipper.Id is null)
                throw new InvalidDataException("Please pass the Shipping Id got thru Order");
            await _shippingServices.CreateShippersAsync(shipper);
            return Ok();
        }

        [HttpPut]
        [Route("kartWebStore/UpdateShipping")]
        [SwaggerResponse(200, Type = typeof(Shippers))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<Shippers>> Update([FromBody] Shippers shippers)
        {

            if (shippers == null)
                throw new ArgumentNullException(nameof(shippers));

            return await _shippingServices.UpdateShippersAsync(shippers);
        }

        [HttpDelete]
        [Route("kartWebStore/DeleteShipping/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async void Delete([FromRoute] Guid? id)
        {
            if (id == Guid.Empty || id is null)
                throw new InvalidDataException("id not specified");
            await _shippingServices.DeleteShippersAsync(id.Value);
        }

        [HttpGet]
        [Route("kartWebStore/GetAllShippings")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<Shippers>))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<List<Shippers>>> GetAll()
        {
            return await _shippingServices.GetAllShippersAsync();
        }
    }
}
