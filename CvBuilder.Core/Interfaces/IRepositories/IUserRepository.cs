namespace CvBuilder.Core.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserProfile(Guid id);
        Task<User> GetUserByUserName(string email);
        Task<List<User>> GetUsersBySearch(string search);

        Task UpdateUser(User entity);
        Task AddAboutMe(AboutMe entity);
        Task AddWorkExperience(WorkExperience entity);
        Task AddSkill(Skill entity);
    }
}
