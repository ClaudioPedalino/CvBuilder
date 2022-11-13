using CvBuilder.Core.UserCases.Commands._03_AddPersonalInfo;
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


        public async Task<ApiResult> UpdatePersonalUserInfo(PersonalUserInfoCommand command)
        {
            var user = await _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            if (user == default)
                return ApiResult.Fail("The user does not exist");

            var entity = user.UpdateBasicInfo(command);

            await _repo.UpdatePersonalUserInfo(entity);

            return ApiResult.Success();
        }


        public async Task<ApiResult> AddAboutMeToUser(AddAboutMeToUserCommand command)
        {
            var entity = UserMapper.Map(command);

            await _repo.AddAboutMeToUser(entity);

            return ApiResult.Success();
        }


        public async Task<ApiResult> AddWorkExperienceToUser(AddWorkExperienceToUserCommand command)
        {
            var entity = UserMapper.Map(command);

            await _repo.AddWorkExperienceToUser(entity);

            return ApiResult.Success();
        }


        public async Task<ApiResult> AddSkillToUser(AddSkillToUserCommand command)
        {
            var entity = UserMapper.Map(command);

            await _repo.AddSkillToUser(entity);

            return ApiResult.Success();
        }

  
    }
}
