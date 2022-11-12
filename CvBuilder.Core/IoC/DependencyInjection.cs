using CvBuilder.Core.Data.Repositories;
using CvBuilder.Core.Identity;
using CvBuilder.Core.Interfaces.IRepositories;
using CvBuilder.Core.Interfaces.IServices;
using CvBuilder.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CvBuilder.Core.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCvBuilderCore(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthTokernHelper, AuthTokernHelper>();

            return services;
        }

    }
}
