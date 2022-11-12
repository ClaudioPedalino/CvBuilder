

namespace CvBuilder.Core.Entities
{
    public class User : IdentityUser
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


        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string CurrentPosition { get; private set; }
        public string Linkedin { get; private set; }
        public string Location { get; private set; }
        public string Github { get; private set; }
        public bool Active { get; private set; }

        public List<AboutMe> AboutMe { get; private set; }
        public List<WorkExperience> WorkExperiences { get; private set; }
        public List<Skill> Skills { get; private set; }
    }
}
