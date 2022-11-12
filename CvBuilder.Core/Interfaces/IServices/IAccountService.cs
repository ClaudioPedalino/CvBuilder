namespace CvBuilder.Core.Interfaces.IServices
{
    public interface IAccountService
    {
        AuthenticationResult RegisterUser(RegisterUserCommand command);
        AuthenticationResult LoginUser(LoginUserCommand command);
    }
}
