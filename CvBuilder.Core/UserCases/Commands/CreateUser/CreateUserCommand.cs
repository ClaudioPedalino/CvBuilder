namespace CvBuilder.Core.UserCases.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string CurrentPosition { get; set; }
        public string Linkedin { get; set; }
        public string Location { get; set; }
        public string Github { get; set; }
    }
}
