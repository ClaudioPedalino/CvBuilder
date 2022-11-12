using CvBuilder.Core.Wrappers;

namespace CvBuilder.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<GetUserResponse>> GetUsers()
        {
            var result = await _repo.GetUsers();

            return UserMapper.Map(result);
        }


        public async Task<ApiResult> AddAboutMeToUser(AddAboutMeToUserCommand command)
        {
            //var user = _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            //if (user == default)
            //    return ApiResult.Fail("The user does not exist");

            var entity = UserMapper.Map(command);

            await _repo.AddAboutMeToUser(entity);

            return ApiResult.Success();
        }


        public async Task<ApiResult> AddWorkExperienceToUser(AddWorkExperienceToUserCommand command)
        {
            //var user = _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            //if (user == default)
            //    return ApiResult.Fail("The user does not exist");

            var entity = UserMapper.Map(command);

            await _repo.AddWorkExperienceToUser(entity);

            return ApiResult.Success();
        }


        public async Task<ApiResult> AddSkillToUser(AddSkillToUserCommand command)
        {
            //var user = _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            //if (user == default)
            //    return ApiResult.Fail("The user does not exist");

            var entity = UserMapper.Map(command);

            await _repo.AddSkillToUser(entity);

            return ApiResult.Success();
        }


    }
}
