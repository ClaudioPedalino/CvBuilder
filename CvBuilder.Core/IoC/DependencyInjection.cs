﻿namespace CvBuilder.Core.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCvBuilderCore(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                options.UseSqlServer(configuration.GetConnectionString("CvBuilderDB"));
            });


            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<IAuthTokernHelper, AuthTokernHelper>();

            //services.AddHealthCheck(configuration);

            services.AddIdentity(configuration);

            services.AddOutputCache();

            services.AddHttpContextAccessor();

            return services;
        }




        public static IApplicationBuilder AddCvBuilderCoreApp(this IApplicationBuilder app, ConfigurationManager configuration)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseOutputCache();

            //app.UseHealthCheck(configuration);

            return app;
        }

    }
}
