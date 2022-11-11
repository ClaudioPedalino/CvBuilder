using CvBuilder.Core.Interfaces.IServices;
using CvBuilder.Core.UserCases.Commands.AddAboutMeToUser;
using CvBuilder.Core.UserCases.Commands.AddSkillToUser;
using CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser;
using CvBuilder.Core.UserCases.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;

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
        public IResult GetUsers()
        {
            return Results.Ok(_service.GetUsers());
        }

        [HttpGet("{id}")]
        public IResult GetUserById([FromRoute] Guid id)
        {
            return default;
        }


        [HttpPost("create")]
        public IResult CreateUser([FromBody] CreateUserCommand command)
        {
            var response = _service.CreateUser(command);

            return Results.Ok(response);
        }


        [HttpPost("add-about-me")]
        public IResult AddAboutMeToUser([FromBody] AddAboutMeToUserCommand command)
        {
            var response = _service.AddAboutMeToUser(command);

            return Results.Ok(response);
        }


        [HttpPost("add-work-experience")]
        public IResult AddWorkExperienceToUser([FromBody] AddWorkExperienceToUserCommand command)
        {
            var response = _service.AddWorkExperienceToUser(command);

            return Results.Ok(response);
        }


        [HttpPost("add-skill")]
        public IResult AddSkillToUser([FromBody] AddSkillToUserCommand command)
        {
            var response = _service.AddSkillToUser(command);

            return Results.Ok(response);
        }
    }
}