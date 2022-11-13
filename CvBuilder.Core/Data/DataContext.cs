using CvBuilder.Core.CustomImplementations;

namespace CvBuilder.Core.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public DbSet<User> Users { get; set; }
        public DbSet<AboutMe> AboutsMe { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userName = _httpContextAccessor.GetUserNameFromToken();

            var user = Users.FirstOrDefault(x => x.UserName == userName);

            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.IsByUser())
                {
                    if (entityEntry.IsNew())
                    {
                        entityEntry.SetTenant(user.Id);
                        entityEntry.SetCreatedDate();
                    }
                    //else if (entityEntry.IsUpdate())
                    //{
                    //    // entityEntry.SetTenant(TenantId); Ver si es necesario
                    //    entityEntry.SetUpdateDate();
                    //}
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
