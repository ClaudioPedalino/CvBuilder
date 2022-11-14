namespace CvBuilder.Core.UserCases.Queries.GetUsers
{
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string CurrentPosition { get; set; }
        public string Email { get; set; }
    }
}
