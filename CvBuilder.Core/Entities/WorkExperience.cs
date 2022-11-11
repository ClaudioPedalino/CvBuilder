namespace CvBuilder.Core.Entities
{
    public class WorkExperience
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyLogo { get; set; }
        public string IsCurrentPosition { get; set; }
        public DateOnly From { get; set; }
        public DateOnly? To { get; set; }
        public string Role { get; set; }
        public string Stack { get; set; }
        public string BusinessSector { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}