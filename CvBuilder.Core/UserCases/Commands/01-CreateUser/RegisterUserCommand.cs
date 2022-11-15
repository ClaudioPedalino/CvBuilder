using Newtonsoft.Json.Linq;

namespace CvBuilder.Core.UserCases.Commands.CreateUser
{
    public record RegisterUserCommand(string Email, string Password) : IRequest<AuthenticationResult>;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthenticationResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthTokernHelper _authTokernHelper;

        public RegisterUserCommandHandler(UserManager<User> userManager, IAuthTokernHelper authTokernHelper)
        {
            _userManager = userManager;
            _authTokernHelper = authTokernHelper;
        }

        public async Task<AuthenticationResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var isExistingUser = await _userManager.FindByEmailAsync(command.Email);
            if (isExistingUser != null)
                return AuthenticationResult.FailAuth("The uses already exist");
            var entity = UserMapper.Map(command);

            var createdUser = await _userManager.CreateAsync(entity, command.Password);

            if (!createdUser.Succeeded)
                return AuthenticationResult.FailAuth(string.Join(" | ", createdUser.Errors));

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(entity);
            
            var confirmResult = await _userManager.ConfirmEmailAsync(entity, token); // TODO: Remove this, send email
            
            //https://learn.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-7.0&tabs=visual-studio

            return AuthenticationResult.SuccessAuth(token, "This is your token to activate your user");
        }
    }
}
