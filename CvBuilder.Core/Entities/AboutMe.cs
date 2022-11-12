using CvBuilder.Core.Interfaces;

namespace CvBuilder.Core.Entities
{
    public class AboutMe : IByUser, IAuditCreation
    {
        public AboutMe(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; set; }
    }
}
