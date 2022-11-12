namespace CvBuilder.Core.Entities
{
    public class Skill
    {
        public Skill(Guid userId, string logo, string title, string shortDescription, string longDescription)
        {
            UserId = userId;
            Logo = logo;
            Title = title;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Logo { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }
    }
}
