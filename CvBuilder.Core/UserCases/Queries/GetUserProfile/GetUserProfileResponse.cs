namespace CvBuilder.Core.UserCases.Queries.GetUserProfile
{
    public record GetUserProfileResponse(Guid Id,
                                         string FirstName,
                                         string LastName,
                                         int Age,
                                         string CurrentPosition,
                                         string Email,
                                         string Linkedin,
                                         string Location,
                                         string Github,
                                         List<AboutMeResponse> AboutMe,
                                         List<WorkExperienceResponse> WorkExperiences,
                                         List<SkillResponse> Skills);
}
