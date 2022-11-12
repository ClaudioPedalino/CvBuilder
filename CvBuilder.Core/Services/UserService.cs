using CvBuilder.Core.Wrappers;

namespace CvBuilder.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<GetUserResponse>> GetUsers()
        {
            var result = await _repo.GetUsers();

            return UserMapper.Map(result);
        }


        public ApiResult AddAboutMeToUser(AddAboutMeToUserCommand command)
        {
            //var user = _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            //if (user == default)
            //    return ApiResult.Fail("The user does not exist");

            var entity = UserMapper.Map(command);

            _repo.AddAboutMeToUser(entity);

            return ApiResult.Success();
        }


        public ApiResult AddWorkExperienceToUser(AddWorkExperienceToUserCommand command)
        {
            var user = _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            if (user == default)
                return ApiResult.Fail("The user does not exist");

            var entity = UserMapper.Map(command, user);

            _repo.AddWorkExperienceToUser(entity);

            return ApiResult.Success();
        }

        public ApiResult AddSkillToUser(AddSkillToUserCommand command)
        {
            var user = _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            if (user == default)
                return ApiResult.Fail("The user does not exist");

            var entity = UserMapper.Map(command, user);

            _repo.AddSkillToUser(entity);

            return ApiResult.Success();
        }


    }
}
