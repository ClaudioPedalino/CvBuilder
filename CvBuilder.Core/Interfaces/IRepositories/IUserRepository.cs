﻿using CvBuilder.Core.Entities;

namespace CvBuilder.Core.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(Guid id);

        void CreateUser(User entity);
        void AddAboutMeToUser(AboutMe entity);
        void AddWorkExperienceToUser(WorkExperience entity);
        void AddSkillToUser(Skill entity);
    }
}