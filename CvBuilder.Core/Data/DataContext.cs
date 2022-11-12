

namespace CvBuilder.Core.Data
{
    public class DataContext : DbContext
    {
        //public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<AboutMe> AboutsMe { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if (!options.IsConfigured)
        //    {
        //        options.UseSqlServer("Server=localhost;Database=CvBuilder2;User Id=sa;Password=Temporal1;TrustServerCertificate=True;");
        //    }
        //}


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }
}
