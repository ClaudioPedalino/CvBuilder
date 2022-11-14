namespace CvBuilder.Core.Enums
{
    public enum SkillEnum
    {
        Backend = 1,
        Frontend = 2,
        Versioning = 3,
        Data = 4,
        Testing = 5,
        Agile = 6,
        Infraestructure = 7,
        Communication = 8,
        Blockchain = 9,
        Languages = 10,
        SoftSkills = 11,
        Other = 12,
    }

    public static class SkillLogos
    {
        public static Dictionary<SkillEnum, string> Data = new Dictionary<SkillEnum, string>()
        {
            {SkillEnum.Backend, "https://static.wixstatic.com/media/29a932_668c804e92e6493b84e1366fab33e3f2~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/backend.png" },
            {SkillEnum.Frontend, "https://static.wixstatic.com/media/29a932_c701e43ea65749dc85eeaec12d75bfb7~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/ux.png" },
            {SkillEnum.Versioning, "https://static.wixstatic.com/media/29a932_98ee6f8ded464e97b2c68fb0a9480c78~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/git.png" },
            {SkillEnum.Data, "https://static.wixstatic.com/media/29a932_f66febe5287040609e057259693306d8~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/database-storage.png" },
            {SkillEnum.Testing, "https://static.wixstatic.com/media/29a932_6c98496b0f924dd9944861ddfc2eb4af~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/icons8-ab-60.png" },
            {SkillEnum.Agile, "https://static.wixstatic.com/media/29a932_797ad1452daf42a8b92bfc83eb941c34~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/scrum.png" },
            {SkillEnum.Infraestructure, "https://static.wixstatic.com/media/29a932_f9ccdc9b14644a5a8dfb5f0230752623~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/infraestructura%20(1).png" },
            {SkillEnum.Communication, "https://static.wixstatic.com/media/29a932_a5b172083c66437d82f9f0ad337ae027~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/http.png" },
            {SkillEnum.Blockchain, "https://static.wixstatic.com/media/29a932_b9f6b3ce50db403c9052b5f2c87e4264~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/blockchain.png" },
            {SkillEnum.Languages, "https://static.wixstatic.com/media/29a932_eca5bf0ea7e64d10aa6d3ba80c4c6a17~mv2.png/v1/fill/w_36,h_36,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/signs.png" },
            {SkillEnum.SoftSkills, "" },
        };
    }
}
