namespace CvBuilder.Core.UserCases.Queries.GetUsers
{
    public class GetUserQuery : IRequest<List<GetUserResponse>> { }


    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserResponse>>
    {
        private readonly IUserRepository _repo;

        public GetUserQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetUsers();

            return UserMapper.Map(result);
        }
    }
}
