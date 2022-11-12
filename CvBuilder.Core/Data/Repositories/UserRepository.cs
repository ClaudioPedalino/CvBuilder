﻿namespace CvBuilder.Core.Data.Repositories
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

        public User GetUserById(Guid id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUserName(string email)
        {
            return _dataContext.Users.FirstOrDefault(x => x.UserName == email);
        }

        public void CreateUser(User entity)
        {
            _dataContext.Users.Add(entity);
            _dataContext.SaveChanges();
        }

        public void AddAboutMeToUser(AboutMe entity)
        {
            _dataContext.AboutsMe.Add(entity);
            _dataContext.SaveChanges();
        }

        public void AddWorkExperienceToUser(WorkExperience entity)
        {
            _dataContext.WorkExperiences.Add(entity);
            _dataContext.SaveChanges();
        }

        public void AddSkillToUser(Skill entity)
        {
            _dataContext.Skills.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
