

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
