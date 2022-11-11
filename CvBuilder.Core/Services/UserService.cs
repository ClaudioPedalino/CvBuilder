using CvBuilder.Core.Interfaces.IRepositories;
using CvBuilder.Core.Interfaces.IServices;
using CvBuilder.Core.Mappers;
using CvBuilder.Core.UserCases.Commands.AddAboutMeToUser;
using CvBuilder.Core.UserCases.Commands.AddSkillToUser;
using CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser;
using CvBuilder.Core.UserCases.Commands.CreateUser;
using CvBuilder.Core.UserCases.Queries.GetUsers;

namespace CvBuilder.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
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
