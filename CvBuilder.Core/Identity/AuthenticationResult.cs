using CvBuilder.Core.Wrappers;

namespace CvBuilder.Core.Identity
{
    public class AuthenticationResult : ApiResult
    {
        public string Token { get; private set; }

        public static AuthenticationResult SuccessAuth(string token, string optionalMessage = "")
        {
            return new AuthenticationResult()
            {
                IsSuccess = true,
                Token = token,
                Message = optionalMessage
            };
        }

        public static AuthenticationResult FailAuth(string errorMessage)
        {
            return new AuthenticationResult()
            {
                IsSuccess = false,
                Message = errorMessage
            };
        }
    }
}
