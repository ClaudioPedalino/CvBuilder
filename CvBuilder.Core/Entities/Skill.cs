namespace CvBuilder.Core.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Logo { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public virtual User User { get; set; }
    }
}
