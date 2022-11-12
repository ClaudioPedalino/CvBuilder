using Microsoft.AspNetCore.OutputCaching;

namespace CvBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [OutputCache(Duration = 5)]
        public async Task<IResult> GetUsers()
        {
            var response = await _service.GetUsers();
            return Results.Ok(response);
        }


        [HttpGet("{id}")]
        //[Authorize]
        //[OutputCache(Duration = 10, VaryByRouteValueNames = new string[] { "*" })]
        //[OutputCache(Duration = 10, VaryByHeaderNames = new string[] { "Authorization" })]
        public IResult GetUserById([FromRoute] Guid id)
        {
            return default;
        }


        [HttpPost("add-about-me")]
        [Authorize]
        public async Task<IResult> AddAboutMeToUser([FromBody] AddAboutMeToUserCommand command)
        {
            var response = _service.AddAboutMeToUser(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("add-work-experience")]
        [Authorize]
        public IResult AddWorkExperienceToUser([FromBody] AddWorkExperienceToUserCommand command)
        {
            var response = _service.AddWorkExperienceToUser(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("add-skill")]
        [Authorize]
        public IResult AddSkillToUser([FromBody] AddSkillToUserCommand command)
        {
            var response = _service.AddSkillToUser(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}