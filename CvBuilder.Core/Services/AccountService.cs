namespace CvBuilder.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthTokernHelper _authTokernHelper;

        public AccountService(UserManager<User> userManager, IAuthTokernHelper authTokernHelper)
        {
            _userManager = userManager;
            _authTokernHelper = authTokernHelper;
        }


        public async Task<AuthenticationResult> LoginUser(LoginUserCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
                return AuthenticationResult.Fail("User or passwords are incorrect");

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, command.Password);
            if (!userHasValidPassword)
                return AuthenticationResult.Fail("User or passwords are incorrect");

            return _authTokernHelper.GenerateAuthResult(user);
        }


        public async Task<AuthenticationResult> RegisterUser(RegisterUserCommand command)
        {
            var isExistingUser = await _userManager.FindByEmailAsync(command.Email);
            if (isExistingUser != null)
                return AuthenticationResult.Fail("The uses already exist");

            var entity = UserMapper.Map(command);

            var createdUser = await _userManager.CreateAsync(entity, command.Password);

            if (!createdUser.Succeeded)
                return AuthenticationResult.Fail(string.Join(" | ", createdUser.Errors));

            return _authTokernHelper.GenerateAuthResult(entity);
        }
    }
}
