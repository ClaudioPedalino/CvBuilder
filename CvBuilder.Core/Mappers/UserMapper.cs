using CvBuilder.Core.Entities;
using CvBuilder.Core.UserCases.Commands.AddAboutMeToUser;
using CvBuilder.Core.UserCases.Commands.AddSkillToUser;
using CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser;
using CvBuilder.Core.UserCases.Commands.CreateUser;
using CvBuilder.Core.UserCases.Queries.GetUsers;

namespace CvBuilder.Core.Mappers
{
    public class UserMapper
    {
        public static List<GetUserResponse> Map(List<User> result)
        {
            return result.ConvertAll(user => new GetUserResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                CurrentPosition = user.CurrentPosition,
                Email = user.Email,
                Linkedin = user.Linkedin,
                Location = user.Location,
                Github = user.Github,
                AboutMe = user.AboutMe.ConvertAll(item => new AboutMeResponse()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                }),
                WorkExperiences = user.WorkExperiences.ConvertAll(item => new WorkExperienceResponse()
                {
                    CompanyName = item.CompanyName,
                    CompanyCountry = item.CompanyCountry,
                    CompanyLogo = item.CompanyLogo,
                    IsCurrentPosition = item.IsCurrentPosition,
                    From = item.From,
                    To = item.To,
                    Role = item.Role,
                    Stack = item.Stack,
                    BusinessSector = item.BusinessSector,
                    Description = item.Description,
                }),
                Skills = user.Skills.ConvertAll(item => new SkillResponse()
                {
                    Logo = item.Logo,
                    Title = item.Title,
                    ShortDescription = item.ShortDescription,
                    LongDescription = item.LongDescription
                })
            });
        }


        public static User Map(RegisterUserCommand input)
        {
            return new User(
                firstName: input.FirstName,
                lastName: input.LastName,
                age: input.Age,
                currentPosition: input.CurrentPosition,
                email: input.Email,
                linkedin: input.Linkedin,
                location: input.Location,
                github: input.Github);
        }


        public static AboutMe Map(AddAboutMeToUserCommand command, User user)
        {
            return new AboutMe()
            {
                UserId = user.Id,
                Title = command.Title,
                Description = command.Description
            };
        }


        public static WorkExperience Map(AddWorkExperienceToUserCommand command, User user)
        {
            return new WorkExperience()
            {
                UserId = user.Id,
                CompanyName = command.CompanyName,
                CompanyCountry = command.CompanyCountry,
                CompanyLogo = command.CompanyLogo,
                IsCurrentPosition = command.IsCurrentPosition,
                From = command.From,
                To = command.To,
                Role = command.Role,
                Stack = command.Stack,
                BusinessSector = command.BusinessSector,
                Description = command.Description,
            };
        }

        public static Skill Map(AddSkillToUserCommand command, User user)
        {
            return new Skill()
            {
                UserId = user.Id,
                Logo = command.Logo,
                Title = command.Title,
                ShortDescription = command.ShortDescription,
                LongDescription = command.LongDescription
            };
        }
    }
}
