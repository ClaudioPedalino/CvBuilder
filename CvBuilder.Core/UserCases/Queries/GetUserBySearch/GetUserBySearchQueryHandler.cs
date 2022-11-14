using CvBuilder.Core.UserCases.Queries.GetUserProfile;

namespace CvBuilder.Core.UserCases.Queries.GetUserBySearch
{
    public class GetUserBySearchQuery : IRequest<List<GetUserProfileResponse>>
    {
        public string Search { get; set; }

        public GetUserBySearchQuery(string search)
        {
            Search = search;
        }
    }


    public class GetUserBySearchQueryHandler : IRequestHandler<GetUserBySearchQuery, List<GetUserProfileResponse>>
    {
        private readonly IUserRepository _repo;

        public GetUserBySearchQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<GetUserProfileResponse>> Handle(GetUserBySearchQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetUsersBySearch(request.Search);

            return default;
        }
    }
}
