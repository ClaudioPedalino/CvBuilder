namespace CvBuilder.Core.IoC
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


            services.AddMediatR(typeof(PersonalUserInfoCommand).GetTypeInfo().Assembly);
            ////.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApiKeyBehaviour<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehaviour<,>));

            services.AddTransient<IUserRepository, UserRepository>();

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
            //app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseOutputCache();

            //app.UseHealthCheck(configuration);

            return app;
        }

    }
}
