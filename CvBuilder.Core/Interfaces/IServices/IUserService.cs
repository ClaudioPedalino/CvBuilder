using CvBuilder.Core.UserCases.Commands.AddAboutMeToUser;
using CvBuilder.Core.UserCases.Commands.AddSkillToUser;
using CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser;
using CvBuilder.Core.UserCases.Commands.CreateUser;
using CvBuilder.Core.UserCases.Queries.GetUsers;

namespace CvBuilder.Core.Interfaces.IServices
{
    public interface IUserService
    {
        List<GetUserResponse> GetUsers();

        string CreateUser(CreateUserCommand command);
        string AddAboutMeToUser(AddAboutMeToUserCommand command);
        string AddWorkExperienceToUser(AddWorkExperienceToUserCommand command);
        string AddSkillToUser(AddSkillToUserCommand command);
    }
}
