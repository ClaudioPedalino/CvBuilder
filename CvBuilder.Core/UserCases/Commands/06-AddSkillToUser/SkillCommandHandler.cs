using CvBuilder.Core.Enums;

namespace CvBuilder.Core.UserCases.Commands.AddSkillToUser
{
    public record AddSkillToUserCommand(SkillEnum skill,
                                        string? Logo,
                                        string? Title,
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
            var (skillTitle, skillLogo) = GetValues(command);

            var entity = UserMapper.Map(command, skillTitle: skillTitle, skillLogo: skillLogo);

            await _repo.AddSkill(entity);

            return ApiResult.Success();
        }


        private static (string skillTitle, string skillLogo) GetValues(AddSkillToUserCommand command)
        {
            string skillTitle = string.Empty;
            string skillLogo = string.Empty;

            if (command.skill == SkillEnum.Other)
            {
                skillTitle = command.Title ?? string.Empty;
                skillLogo = command.Logo ?? string.Empty;
            }
            else
            {
                skillTitle = Enum.GetName(typeof(SkillEnum), command.skill);
                skillLogo = SkillLogos.Data.GetValueOrDefault(command.skill);
            }
            
            return (SkillTitle: skillTitle, SkillLogo: skillLogo);
        }
    }
}
