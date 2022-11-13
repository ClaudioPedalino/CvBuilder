

using CvBuilder.Core.UserCases.Commands._03_AddPersonalInfo;
using CvBuilder.Core.Wrappers;

namespace CvBuilder.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<List<GetUserResponse>> GetUsers();

        Task<ApiResult> UpdatePersonalUserInfo(PersonalUserInfoCommand command);
        Task<ApiResult> AddAboutMeToUser(AddAboutMeToUserCommand command);
        Task<ApiResult> AddWorkExperienceToUser(AddWorkExperienceToUserCommand command);
        Task<ApiResult> AddSkillToUser(AddSkillToUserCommand command);
    }
}
