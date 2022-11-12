using CvBuilder.Core.Interfaces;

namespace CvBuilder.Core.Entities
{
    public class Skill : IByUser, IAuditCreation
    {
        public Skill(string logo, string title, string shortDescription, string longDescription)
        {
            Logo = logo;
            Title = title;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; set; }
        public string Logo { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }
        public DateTime CreatedAt { get; set; }
    }
}
