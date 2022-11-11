namespace CvBuilder.Core.UserCases.Queries.GetUsers
{
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string CurrentPosition { get; set; }
        public string Email { get; set; }
        public string Linkedin { get; set; }
        public string Location { get; set; }
        public string Github { get; set; }
        public List<AboutMeResponse> AboutMe { get; set; }
        public List<WorkExperienceResponse> WorkExperiences { get; set; }
        public List<SkillResponse> Skills { get; set; }
    }


    public class AboutMeResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }


    public class WorkExperienceResponse
    {
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
    }

    public class SkillResponse
    {
        public string Logo { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
