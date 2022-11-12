
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
            return new AboutMe(userId: user.Id,
                               title: command.Title,
                               description: command.Description);
        }


        public static WorkExperience Map(AddWorkExperienceToUserCommand command, User user)
        {
            return new WorkExperience(
                userId: user.Id,
                companyName: command.CompanyName,
                companyCountry: command.CompanyCountry,
                companyLogo: command.CompanyLogo,
                isCurrentPosition: command.IsCurrentPosition ?? false,
                from: command.From,
                to: command.To,
                role: command.Role,
                stack: command.Stack,
                businessSector: command.BusinessSector,
                description: command.Description);
        }

        public static Skill Map(AddSkillToUserCommand command, User user)
        {
            return new Skill(userId: user.Id,
                             logo: command.Logo,
                             title: command.Title,
                             shortDescription: command.ShortDescription,
                             longDescription: command.LongDescription);
        }
    }
}
