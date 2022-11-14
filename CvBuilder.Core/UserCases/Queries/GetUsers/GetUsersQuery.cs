namespace CvBuilder.Core.UserCases.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<GetUserResponse>> { }


    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, List<GetUserResponse>>
    {
        private readonly IUserRepository _repo;

        public GetUserQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<GetUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetUsers();

            return UserMapper.Map(result);
        }
    }
}
