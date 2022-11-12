using CvBuilder.Core.Interfaces;

namespace CvBuilder.Core.Entities
{
    public class WorkExperience : IByUser, IAuditCreation
    {
        public WorkExperience(string companyName, string companyCountry, string companyLogo, bool isCurrentPosition, DateOnly from, DateOnly? to, string role, string stack, string businessSector, string description)
        {
            CompanyName = companyName;
            CompanyCountry = companyCountry;
            CompanyLogo = companyLogo;
            IsCurrentPosition = isCurrentPosition;
            From = from;
            To = to;
            Role = role;
            Stack = stack;
            BusinessSector = businessSector;
            Description = description;
        }


        public Guid Id { get; private set; }
        public Guid UserId { get; set; }
        public string CompanyName { get; private set; }
        public string CompanyCountry { get; private set; }
        public string CompanyLogo { get; private set; }
        public bool IsCurrentPosition { get; private set; }
        public DateOnly From { get; private set; }
        public DateOnly? To { get; private set; }
        public string Role { get; private set; }
        public string Stack { get; private set; }
        public string BusinessSector { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; set; }
    }
}