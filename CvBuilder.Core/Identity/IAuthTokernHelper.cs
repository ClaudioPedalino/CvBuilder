using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvBuilder.Core.Identity
{
    public interface IAuthTokernHelper
    {
        AuthenticationResult GenerateAuthResult(IdentityUser newUser);
    }
}
