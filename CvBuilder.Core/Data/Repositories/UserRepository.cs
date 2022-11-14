namespace CvBuilder.Core.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) => _dataContext = dataContext;
        public async Task Save() => await _dataContext.SaveChangesAsync();


        public async Task<List<User>> GetUsers()
        {
            return await _dataContext.Users
                .Where(x => x.Active)
                .ToListAsync();
        }


        public async Task<User> GetUserProfile(Guid id)
        {
            return await _dataContext.Users
                .Include(x => x.AboutMe)
                .Include(x => x.WorkExperiences)
                .Include(x => x.Skills)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<User> GetUserByUserName(string email)
            => await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == email);


        public async Task UpdateUser(User entity)
        {
            _dataContext.Users.Update(entity);
            await Save();
        }


        public async Task AddAboutMe(AboutMe entity)
        {
            await _dataContext.AboutsMe.AddAsync(entity);
            await Save();
        }


        public async Task AddWorkExperience(WorkExperience entity)
        {
            await _dataContext.WorkExperiences.AddAsync(entity);
            await Save();
        }


        public async Task AddSkill(Skill entity)
        {
            await _dataContext.Skills.AddAsync(entity);
            await Save();
        }

    }
}
