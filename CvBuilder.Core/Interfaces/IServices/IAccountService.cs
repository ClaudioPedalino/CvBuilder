namespace CvBuilder.Core.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<AuthenticationResult> RegisterUser(RegisterUserCommand command);
        Task<AuthenticationResult> LoginUser(LoginUserCommand command);
    }
}
