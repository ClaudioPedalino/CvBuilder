namespace CvBuilder.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public AccountController(IServiceProvider serviceProvider) : base(serviceProvider) { }


        [HttpPost("login")]
        public async Task<IResult> LoginUser([FromBody] LoginUserCommand command)
            => await Mediator.SendCommand(command);



        [HttpPost("register")]
        public async Task<IResult> RegisterUser([FromBody] RegisterUserCommand command)
            => await Mediator.SendCommand(command);


        [HttpPost("confirm")]
        public IResult ConfirmUser()
        {
            return default;
        }
    }
}
