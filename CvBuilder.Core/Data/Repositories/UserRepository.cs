namespace CvBuilder.Core.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dataContext.Users
                .Include(x => x.AboutMe)
                .Include(x => x.WorkExperiences)
                .Include(x => x.Skills)
                .ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByUserName(string email)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == email);
        }

        public async Task CreateUser(User entity)
        {
            await _dataContext.Users.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddAboutMeToUser(AboutMe entity)
        {
            await _dataContext.AboutsMe.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddWorkExperienceToUser(WorkExperience entity)
        {
            await _dataContext.WorkExperiences.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddSkillToUser(Skill entity)
        {
            await _dataContext.Skills.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
