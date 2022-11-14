using CvBuilder.Api.Controllers.Base;
using CvBuilder.Core.UserCases.Commands._03_AddPersonalInfo;
using CvBuilder.Core.UserCases.Commands._07_UpdateUserPhotoUrl;
using CvBuilder.Core.UserCases.Queries.GetUsers;
using Microsoft.AspNetCore.OutputCaching;

namespace CvBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider) { }


        [HttpGet]
        [OutputCache(Duration = 5)]
        public async Task<IResult> GetUsers([FromQuery] GetUserQuery query)
        {
            return Results.Ok(await Mediator.Send(query));
        }


        [HttpGet("{id}")]
        //[Authorize]
        public IResult GetUserById([FromRoute] Guid id)
        {
            return default;
        }


        [HttpPost("add-personal-info")]
        [Authorize]
        public async Task<IResult> AddPersonalUserInfo([FromBody] PersonalUserInfoCommand command)
        {
            var response = await Mediator.Send(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("update-user-photo-url")]
        [Authorize]
        public async Task<IResult> UpdateUserPhotoUrl([FromBody] UserPhotoUrlCommand command)
        {
            var response = await Mediator.Send(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("add-about-me")]
        [Authorize]
        public async Task<IResult> AddAboutMeToUser([FromBody] AddAboutMeToUserCommand command)
        {
            var response = await Mediator.Send(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("add-work-experience")]
        [Authorize]
        public async Task<IResult> AddWorkExperienceToUser([FromBody] AddWorkExperienceToUserCommand command)
        {
            var response = await Mediator.Send(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }


        [HttpPost("add-skill")]
        [Authorize]
        public async Task<IResult> AddSkillToUser([FromBody] AddSkillToUserCommand command)
        {
            var response = await Mediator.Send(command);

            return response.IsSuccess
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }
    }
}