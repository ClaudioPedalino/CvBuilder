using CvBuilder.Core.Entities;
using CvBuilder.Core.Identity;
using CvBuilder.Core.Interfaces.IRepositories;
using CvBuilder.Core.Interfaces.IServices;
using CvBuilder.Core.Mappers;
using CvBuilder.Core.UserCases.Commands.AddAboutMeToUser;
using CvBuilder.Core.UserCases.Commands.AddSkillToUser;
using CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser;
using CvBuilder.Core.UserCases.Commands.CreateUser;
using CvBuilder.Core.UserCases.Queries.GetUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CvBuilder.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly IAuthTokernHelper _authTokernHelper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repo, UserManager<User> userManager, IConfiguration configuration, IAuthTokernHelper authTokernHelper)
        {
            _repo = repo;
            _userManager = userManager;
            _configuration = configuration;
            _authTokernHelper = authTokernHelper;
        }


        public List<GetUserResponse> GetUsers()
        {
            var result = _repo.GetUsers();

            return UserMapper.Map(result);
        }


        public string CreateUser(CreateUserCommand command)
        {
            var entity = UserMapper.Map(command);

            _repo.CreateUser(entity);

            return "ok";
        }


        public AuthenticationResult RegisterUser(CreateUserCommand command)
        {
            var existingUser = _userManager.FindByEmailAsync(command.Email).Result;
            if (existingUser != null)
            {
                return new AuthenticationResult()
                {
                    Success = false,
                    ErrorMessages = new string[] { "The uses already exist" }
                };
            }


            var entity = UserMapper.Map(command);

            var createdUser = _userManager.CreateAsync(entity, command.Password).Result;

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    ErrorMessages = createdUser.Errors.Select(x => x.Description)
                };
            }

            return _authTokernHelper.GenerateAuthResult(entity);
        }


        public string AddAboutMeToUser(AddAboutMeToUserCommand command)
        {
            var user = _repo.GetUserById(command.UserId);

            if (user == default)
                return "The user does not exist";

            var entity = UserMapper.Map(command, user);

            _repo.AddAboutMeToUser(entity);

            return "ok";
        }


        public string AddWorkExperienceToUser(AddWorkExperienceToUserCommand command)
        {
            var user = _repo.GetUserById(command.UserId);

            if (user == default)
                return "The user does not exist";

            var entity = UserMapper.Map(command, user);

            _repo.AddWorkExperienceToUser(entity);

            return "ok";
        }

        public string AddSkillToUser(AddSkillToUserCommand command)
        {
            var user = _repo.GetUserById(command.UserId);

            if (user == default)
                return "The user does not exist";

            var entity = UserMapper.Map(command, user);

            _repo.AddSkillToUser(entity);

            return "ok";
        }
    }
}
