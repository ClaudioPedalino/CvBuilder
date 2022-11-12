

using CvBuilder.Core.Wrappers;

namespace CvBuilder.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<List<GetUserResponse>> GetUsers();


        Task<ApiResult> AddAboutMeToUser(AddAboutMeToUserCommand command);
        Task<ApiResult> AddWorkExperienceToUser(AddWorkExperienceToUserCommand command);
        Task<ApiResult> AddSkillToUser(AddSkillToUserCommand command);
    }
}
