

namespace CvBuilder.Core.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByUserName(string email);

        Task CreateUser(User entity);
        Task AddAboutMeToUser(AboutMe entity);
        Task AddWorkExperienceToUser(WorkExperience entity);
        Task AddSkillToUser(Skill entity);
    }
}
