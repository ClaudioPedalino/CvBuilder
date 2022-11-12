

using CvBuilder.Core.Wrappers;

namespace CvBuilder.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<List<GetUserResponse>> GetUsers();

        

        ApiResult AddAboutMeToUser(AddAboutMeToUserCommand command);
        ApiResult AddWorkExperienceToUser(AddWorkExperienceToUserCommand command);
        ApiResult AddSkillToUser(AddSkillToUserCommand command);
    }
}
