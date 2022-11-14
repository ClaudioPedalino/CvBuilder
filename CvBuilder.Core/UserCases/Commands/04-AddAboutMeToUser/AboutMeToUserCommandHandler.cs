namespace CvBuilder.Core.UserCases.Commands.AddAboutMeToUser
{
    public record AddAboutMeToUserCommand(string Title, string Description) : IRequest<ApiResult>;


    public class AboutMeToUserCommandHandler : IRequestHandler<AddAboutMeToUserCommand, ApiResult>
    {
        private readonly IUserRepository _repo;

        public AboutMeToUserCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResult> Handle(AddAboutMeToUserCommand command, CancellationToken cancellationToken)
        {
            var entity = UserMapper.Map(command);

            await _repo.AddAboutMe(entity);

            return ApiResult.Success();
        }
    }

}
