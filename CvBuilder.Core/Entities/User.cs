namespace CvBuilder.Core.Entities
{
    public class User : IdentityUser, IAuditCreation
    {
        public User(string firstName,
                    string lastName,
                    int age,
                    string currentPosition,
                    string email,
                    string linkedin,
                    string location,
                    string github)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            CurrentPosition = currentPosition;
            Email = email;
            Linkedin = linkedin;
            Location = location;
            Github = github;

            UserName = email;
            Active = true;
            WorkExperiences = new List<WorkExperience>();
            Skills = new List<Skill>();
        }

        public User(string email)
        {
            Email = email;

            UserName = email;
            Active = true;
            AboutMe = new List<AboutMe>();
            WorkExperiences = new List<WorkExperience>();
            Skills = new List<Skill>();
        }


        public Guid Id { get; private set; }
        public string? PhotoUrl { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public int? Age { get; private set; }
        public string? CurrentPosition { get; private set; }
        public string? Linkedin { get; private set; }
        public string? Location { get; private set; }
        public string? Github { get; private set; }
        public bool Active { get; private set; }

        public List<AboutMe> AboutMe { get; private set; }
        public List<WorkExperience> WorkExperiences { get; private set; }
        public List<Skill> Skills { get; private set; }
        public DateTime CreatedAt { get; set; }



        public User UpdateBasicInfo(PersonalUserInfoCommand command)
        {
            FirstName = !string.IsNullOrWhiteSpace(command.FirstName) ? command.FirstName : default;
            LastName = !string.IsNullOrWhiteSpace(command.LastName) ? command.LastName : default;
            if (command.Age > 16) Age = command.Age;
            CurrentPosition = !string.IsNullOrWhiteSpace(command.CurrentPosition) ? command.CurrentPosition : default;
            Linkedin = !string.IsNullOrWhiteSpace(command.Linkedin) ? command.Linkedin : default;
            Location = !string.IsNullOrWhiteSpace(command.Location) ? command.Location : default;
            Github = !string.IsNullOrWhiteSpace(command.Github) ? command.Github : default;

            return this;
        }

        public User UpdateUserPhotoUrl(UserPhotoUrlCommand command)
        {
            PhotoUrl = !string.IsNullOrWhiteSpace(command.PhotoUrl) ? command.PhotoUrl : default;

            return this;
        }
    }
}
