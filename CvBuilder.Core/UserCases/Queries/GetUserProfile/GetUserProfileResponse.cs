using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvBuilder.Core.UserCases.Queries.GetUserProfile
{
    public class GetUserProfileResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string CurrentPosition { get; set; }
        public string Email { get; set; }
        public string Linkedin { get; set; }
        public string Location { get; set; }
        public string Github { get; set; }
        public List<AboutMeResponse> AboutMe { get; set; }
        public List<WorkExperienceResponse> WorkExperiences { get; set; }
        public List<SkillResponse> Skills { get; set; }
    }
}
