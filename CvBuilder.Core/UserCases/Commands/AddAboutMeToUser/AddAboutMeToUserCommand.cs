namespace CvBuilder.Core.UserCases.Commands.AddAboutMeToUser
{
    public class AddAboutMeToUserCommand
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
