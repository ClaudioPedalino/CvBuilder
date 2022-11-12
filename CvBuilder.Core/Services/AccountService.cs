using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
