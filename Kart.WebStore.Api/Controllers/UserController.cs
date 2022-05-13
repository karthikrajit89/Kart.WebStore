using Microsoft.AspNetCore.Mvc;
using Kart.WebStore.Services.Services;
using Kart.WebStore.Domain;
using Swashbuckle.AspNetCore.Annotations;

namespace Kart.WebStore.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController (IUserService userService)
        {
            _userService = userService; 
        }

        [HttpPost]
        [Route("kartWebstore/GetUser")]
        [SwaggerResponse(200, Type = typeof(User))]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<User>> Get([FromBody] Signin signinData)
        {
            if (string.IsNullOrEmpty(signinData.Email))
                throw new InvalidDataException("emailid not specified");

            var user = await _userService.GetAsync(signinData.Email);
            if (user == null)
                return NotFound($"user with the ${signinData.Email} not found");

            if (user.Password != signinData.Password)
                return NotFound("credentials not matching");

            return Ok(user);
        }
        [HttpPost]
        [Route("kartWebStore/CreateUser")]
        [SwaggerResponse(200)]
        [SwaggerResponse(500, "Something went wrong internally")]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (String.IsNullOrEmpty(user.Name) && String.IsNullOrEmpty(user.Email) && string.IsNullOrEmpty(user.Password))
                throw new InvalidDataException("User Object with Name,Email, password is mandatory");

            return await _userService.CreateAsync(user);

        }
    }
}
