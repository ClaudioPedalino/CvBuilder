using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CvBuilder.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpPost("login")]
        public async Task<IResult> LoginUser([FromBody] LoginUserCommand command)
        {
            var response = await _service.LoginUser(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("register")]
        public async Task<IResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var response = await _service.RegisterUser(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("confirm")]
        public IResult ConfirmUser()
        {
            return default;
        }
    }
}
