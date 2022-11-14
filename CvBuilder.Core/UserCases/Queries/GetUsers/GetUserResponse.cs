namespace CvBuilder.Core.UserCases.Queries.GetUsers
{
    public record GetUserResponse(
        Guid Id,
        string FullName,
        string CurrentPosition,
        string Email);
}
