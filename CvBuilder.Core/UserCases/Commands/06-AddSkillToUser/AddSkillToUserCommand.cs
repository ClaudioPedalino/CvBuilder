namespace CvBuilder.Core.UserCases.Commands.AddSkillToUser
{
    public class AddSkillToUserCommand
    {
        public Guid UserId { get; set; }
        public string Logo { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
