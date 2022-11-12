using CvBuilder.Core.Wrappers;

namespace CvBuilder.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly IAuthTokernHelper _authTokernHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository repo, UserManager<User> userManager, IAuthTokernHelper authTokernHelper, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _userManager = userManager;
            _authTokernHelper = authTokernHelper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<GetUserResponse>> GetUsers()
        {
            var result = await _repo.GetUsers();

            return UserMapper.Map(result);
        }


        public AuthenticationResult LoginUser(LoginUserCommand command)
        {
            var user = _userManager.FindByEmailAsync(command.Email).Result;
            if (user == null)
                return AuthenticationResult.Fail("User or passwords are incorrect");

            var userHasValidPassword = _userManager.CheckPasswordAsync(user, command.Password).Result;
            if (!userHasValidPassword)
                return AuthenticationResult.Fail("User or passwords are incorrect");

            return _authTokernHelper.GenerateAuthResult(user);
        }


        public AuthenticationResult RegisterUser(RegisterUserCommand command)
        {
            var isExistingUser = _userManager.FindByEmailAsync(command.Email).Result;
            if (isExistingUser != null)
                return AuthenticationResult.Fail("The uses already exist");

            var entity = UserMapper.Map(command);

            var createdUser = _userManager.CreateAsync(entity, command.Password).Result;

            if (!createdUser.Succeeded)
                return AuthenticationResult.Fail(string.Join(" | ", createdUser.Errors));

            return _authTokernHelper.GenerateAuthResult(entity);
        }


        public ApiResult AddAboutMeToUser(AddAboutMeToUserCommand command)
        {
            var user = _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            if (user == default)
                return ApiResult.Fail("The user does not exist");

            var entity = UserMapper.Map(command, user);

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
