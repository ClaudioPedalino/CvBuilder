namespace CvBuilder.Core.UserCases.Queries.GetUserProfile
{
    public record GetUserProfileQuery(Guid Id) : IRequest<GetUserProfileResponse>;


    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, GetUserProfileResponse>
    {
        private readonly IUserRepository _repo;

        public GetUserProfileQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }


        public async Task<GetUserProfileResponse> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetUserProfile(request.Id);

            return UserMapper.Map(result);
        }
    }
}
