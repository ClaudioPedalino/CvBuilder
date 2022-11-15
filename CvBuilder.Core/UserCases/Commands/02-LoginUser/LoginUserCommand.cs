namespace CvBuilder.Core.UserCases.Commands.LoginUser
{
    public record LoginUserCommand(string Email, string Password) : IRequest<AuthenticationResult>;


    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthenticationResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthTokernHelper _authTokernHelper;

        public LoginUserCommandHandler(UserManager<User> userManager, IAuthTokernHelper authTokernHelper)
        {
            _userManager = userManager;
            _authTokernHelper = authTokernHelper;
        }

        public async Task<AuthenticationResult> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
                return AuthenticationResult.FailAuth("User or passwords are incorrect");

            var isConfirm = await _userManager.IsEmailConfirmedAsync(user);
            if (!isConfirm)
                return AuthenticationResult.FailAuth("You need to activate your user first");

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, command.Password);
            if (!userHasValidPassword)
                return AuthenticationResult.FailAuth("User or passwords are incorrect");

            return _authTokernHelper.GenerateAuthResult(user);
        }
    }
}
