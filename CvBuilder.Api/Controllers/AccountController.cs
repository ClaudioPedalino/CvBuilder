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
        public IResult LoginUser([FromBody] LoginUserCommand command)
        {
            var response = _service.LoginUser(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("register")]
        public IResult RegisterUser([FromBody] RegisterUserCommand command)
        {
            var response = _service.RegisterUser(command);

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
