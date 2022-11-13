

namespace CvBuilder.Core.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByUserName(string email);

        Task UpdateUser(User entity);
        Task AddAboutMe(AboutMe entity);
        Task AddWorkExperience(WorkExperience entity);
        Task AddSkill(Skill entity);
    }
}
