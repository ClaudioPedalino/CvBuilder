

namespace CvBuilder.Core.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCvBuilderCore(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CvBuilderDB")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthTokernHelper, AuthTokernHelper>();

            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services
                .AddAuthorization()
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<DataContext>();


            return services;
        }

    }
}
