namespace CvBuilder.Core.UserCases.Queries.GetUserProfile
{
    public record WorkExperienceResponse(string CompanyName,
                                         string CompanyCountry,
                                         string CompanyLogo,
                                         bool IsCurrentPosition,
                                         DateOnly From,
                                         DateOnly? To,
                                         string Role,
                                         string Stack,
                                         string BusinessSector,
                                         string Description);
}
