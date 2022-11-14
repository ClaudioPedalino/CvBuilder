namespace CvBuilder.Core.UserCases.Queries.GetUserProfile
{


    public class WorkExperienceResponse
    {
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyLogo { get; set; }
        public bool IsCurrentPosition { get; set; }
        public DateOnly From { get; set; }
        public DateOnly? To { get; set; }
        public string Role { get; set; }
        public string Stack { get; set; }
        public string BusinessSector { get; set; }
        public string Description { get; set; }
    }
}
