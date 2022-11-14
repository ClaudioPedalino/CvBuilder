using CvBuilder.Core.UserCases.Queries.GetUserBySearch;

namespace CvBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider) { }


        [HttpGet]
        [OutputCache(Duration = 30)]
        //[Authorize]
        public async Task<IResult> GetUsers([FromQuery] GetUsersQuery query)
        {
            return Results.Ok(await Mediator.Send(query));
        }


        [HttpGet("{id}")]
        [OutputCache(Duration = 30)]
        //[Authorize]
        public async Task<IResult> GetUserById([FromRoute] Guid id)
        {
            return Results.Ok(await Mediator.Send(new GetUserProfileQuery(id)));
        }

        [HttpGet("search")]
        //[Authorize]
        public async Task<IResult> GetUserBySearch([FromQuery] string search)
        {
            return Results.Ok(await Mediator.Send(new GetUserBySearchQuery(search)));
        }


        [HttpPost("add-personal-info")]
        [Authorize]
        public async Task<IResult> AddPersonalUserInfo([FromBody] PersonalUserInfoCommand command)
            => await Mediator.SendCommand(command);


        [HttpPost("update-user-photo-url")]
        [Authorize]
        public async Task<IResult> UpdateUserPhotoUrl([FromBody] UserPhotoUrlCommand command)
            => await Mediator.SendCommand(command);


        [HttpPost("add-about-me")]
        [Authorize]
        public async Task<IResult> AddAboutMeToUser([FromBody] AddAboutMeToUserCommand command)
            => await Mediator.SendCommand(command);


        [HttpPost("add-work-experience")]
        [Authorize]
        public async Task<IResult> AddWorkExperienceToUser([FromBody] AddWorkExperienceToUserCommand command)
            => await Mediator.SendCommand(command);


        [HttpPost("add-skill")]
        [Authorize]
        public async Task<IResult> AddSkillToUser([FromBody] AddSkillToUserCommand command)
            => await Mediator.SendCommand(command);
    }
}