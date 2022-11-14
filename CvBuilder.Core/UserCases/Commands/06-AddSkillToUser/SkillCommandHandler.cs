namespace CvBuilder.Core.UserCases.Commands.AddSkillToUser
{
    public record AddSkillToUserCommand(string Logo,
                                        string Title,
                                        string ShortDescription,
                                        string LongDescription) : IRequest<ApiResult>;


    public class SkillCommandHandler : IRequestHandler<AddSkillToUserCommand, ApiResult>
    {
        private readonly IUserRepository _repo;

        public SkillCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResult> Handle(AddSkillToUserCommand command, CancellationToken cancellationToken)
        {
            var entity = UserMapper.Map(command);

            await _repo.AddSkill(entity);

            return ApiResult.Success();
        }
    }
}
