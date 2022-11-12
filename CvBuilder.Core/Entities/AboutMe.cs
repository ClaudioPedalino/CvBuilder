namespace CvBuilder.Core.Entities
{
    public class AboutMe
    {
        public AboutMe(Guid userId, string title, string description)
        {
            UserId = userId;
            Title = title;
            Description = description;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
