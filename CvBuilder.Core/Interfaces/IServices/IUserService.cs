using CvBuilder.Core.Identity;
using CvBuilder.Core.UserCases.Commands.AddAboutMeToUser;
using CvBuilder.Core.UserCases.Commands.AddSkillToUser;
using CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser;
using CvBuilder.Core.UserCases.Commands.CreateUser;
using CvBuilder.Core.UserCases.Commands.LoginUser;
using CvBuilder.Core.UserCases.Queries.GetUsers;

namespace CvBuilder.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<List<GetUserResponse>> GetUsers();

        AuthenticationResult RegisterUser(RegisterUserCommand command);
        AuthenticationResult LoginUser(LoginUserCommand command);

        string AddAboutMeToUser(AddAboutMeToUserCommand command);
        string AddWorkExperienceToUser(AddWorkExperienceToUserCommand command);
        string AddSkillToUser(AddSkillToUserCommand command);
    }
}
