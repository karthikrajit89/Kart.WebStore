using Microsoft.AspNetCore.Mvc;
using Kart.WebStore.Services.Services;
using Kart.WebStore.Domain;
using Swashbuckle.AspNetCore.Annotations;

namespace Kart.WebStore.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        [Route("kartWebstore/GetOrder/{id}")]
        [SwaggerResponse(200, Type = typeof(Order))]
        [SwaggerResponse(500,"Something went wrong internally")]
        public async Task<ActionResult<Order>> Get([FromRoute] Guid? id)
        {
            if (id == Guid.Empty || id is null)
                throw new InvalidDataException("id not specified");
           var order = await _orderServices.GetOrderAsync(id.Value);
            if (order == null)
                return NotFound("Order with the Id not found");
            return Ok(order);
        }

        [HttpPost]
        [Route("kartWebStore/CreateOrder")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<Order>> Create([FromBody] Order order)
        {
            if(order == null)   
                throw new ArgumentNullException(nameof(order));
            if (order.CartFinalList.Any(x=>String.IsNullOrEmpty(x.ProductId)))
                throw new InvalidDataException("Cannot create order for No product");
            return await _orderServices.CreateOrderAsync(order);
            
        }

        [HttpPut]
        [Route("kartWebStore/UpdateOrder")]
        [SwaggerResponse(200, Type = typeof(Order))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<Order>> Update([FromBody] Order order)
        {
          
            if(order == null)   
                throw new ArgumentNullException(nameof(order));

            return await _orderServices.UpdateOrderAsync(order);
        }

        [HttpDelete]
        [Route("kartWebStore/DeleteOrder/{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async void Delete([FromRoute] Guid? id)
        {
            if(id == Guid.Empty || id is null)
                throw new InvalidDataException("id not specified");
            await _orderServices.DeleteOrderAsync(id.Value);
        }

        [HttpGet]
        [Route("kartWebStore/GetAllOrders")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<Order>))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
           return await _orderServices.GetAllOrdersAsync();
        }

    }
}
