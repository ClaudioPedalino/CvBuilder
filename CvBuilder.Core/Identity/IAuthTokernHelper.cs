using Microsoft.AspNetCore.Identity;

namespace CvBuilder.Core.Identity
{
    public interface IAuthTokernHelper
    {
        AuthenticationResult GenerateAuthResult(IdentityUser newUser);
    }
}
