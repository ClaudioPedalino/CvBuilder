namespace CvBuilder.Core.UserCases.Commands.AddWorkExperienceToUser
{
    public record AddWorkExperienceToUserCommand(string CompanyName,
                                                 string CompanyCountry,
                                                 string CompanyLogo,
                                                 bool? IsCurrentPosition,
                                                 DateOnly From,
                                                 DateOnly? To,
                                                 string Role,
                                                 string Stack,
                                                 string BusinessSector,
                                                 string Description) : IRequest<ApiResult>;


    public class WorkExperienceCommandHandler : IRequestHandler<AddWorkExperienceToUserCommand, ApiResult>
    {
        private readonly IUserRepository _repo;

        public WorkExperienceCommandHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResult> Handle(AddWorkExperienceToUserCommand command, CancellationToken cancellationToken)
        {
            var entity = UserMapper.Map(command);

            await _repo.AddWorkExperience(entity);

            return ApiResult.Success();
        }
    }
}
