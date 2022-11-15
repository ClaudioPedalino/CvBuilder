namespace CvBuilder.Core.UserCases.Commands._08_ConfirmUser
{
    public record ConfirmUserCommand(string Email, string ConfirmationToken) : IRequest<AuthenticationResult>;


    public class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand, AuthenticationResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthTokernHelper _authTokernHelper;

        public ConfirmUserCommandHandler(UserManager<User> userManager, IAuthTokernHelper authTokernHelper)
        {
            _userManager = userManager;
            _authTokernHelper = authTokernHelper;
        }

        public async Task<AuthenticationResult> Handle(ConfirmUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
                return AuthenticationResult.FailAuth("User incorrect");

            var confirmResult = await _userManager.ConfirmEmailAsync(user, command.ConfirmationToken); // TODO: Remove this, send email
            if (!confirmResult.Succeeded)
                return AuthenticationResult.FailAuth("User incorrect");

            var isConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return isConfirmed && confirmResult.Succeeded
                ? _authTokernHelper.GenerateAuthResult(user)
                : AuthenticationResult.FailAuth("User incorrect");
        }
    }
}
