namespace CvBuilder.Core.UserCases.Commands._07_UpdateUserPhotoUrl
{
    public record UserPhotoUrlCommand(string PhotoUrl) : IRequest<ApiResult>;


    public class UpdateUserPhotoUrlCommandHanlder : IRequestHandler<UserPhotoUrlCommand, ApiResult>
    {
        private readonly IUserRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateUserPhotoUrlCommandHanlder(IUserRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult> Handle(UserPhotoUrlCommand command, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserByUserName(_httpContextAccessor.GetUserNameFromToken());

            if (user == default)
                return ApiResult.Fail("The user does not exist");

            var entity = user.UpdateUserPhotoUrl(command);

            await _repo.UpdateUser(entity);

            return ApiResult.Success();
        }
    }
}
