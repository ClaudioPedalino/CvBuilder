namespace CvBuilder.Core.UserCases.Commands._03_AddPersonalInfo
{
    public record PersonalUserInfoCommand(string FirstName,
                                          string LastName,
                                          int Age,
                                          string CurrentPosition,
                                          string Linkedin,
                                          string Location,
                                          string Github) : IRequest<ApiResult>;


    public class AddPersonalUserInfoCommandHandler : IRequestHandler<PersonalUserInfoCommand, ApiResult>
    {
        private readonly IUserRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddPersonalUserInfoCommandHandler(IUserRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult> Handle(PersonalUserInfoCommand command, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            if (user == default)
                return ApiResult.Fail("The user does not exist");

            var entity = user.UpdateBasicInfo(command);

            await _repo.UpdateUser(entity);

            return ApiResult.Success();
        }
    }
}
