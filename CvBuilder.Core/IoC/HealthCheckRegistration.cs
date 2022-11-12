using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvBuilder.Core.IoC
{
    public static class HealthCheckRegistration
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddHealthChecks()
                .AddCheck("Mock Service 1", () => HealthCheckResult.Healthy("Service 1 ok"))
                .AddUrlGroup(
                    uri: new Uri("https://google.com"),
                    name: "CoinMarketCap WebSite",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new string[] { "client", "http", "external" })
                .AddSqlServer(
                    connectionString: configuration.GetConnectionString("CvBuilderDB"),
                    healthQuery: "SELECT 1;",
                    name: "SQLServerDb-check",
                    failureStatus: HealthStatus.Degraded,
                    tags: new string[] { "Cv Builder Db" });

            services.AddHealthChecksUI()
                .AddSqlServerStorage(configuration.GetConnectionString("CvBuilderDB"));

            return services;
        }

        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app, ConfigurationManager configuration)
        {
            app.UseEndpoints(config =>
            {
                config.MapHealthChecksUI();

                config.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                //config.MapHealthChecksUI(setup =>
                //{
                //    setup.UIPath = "/hc-ui";
                //    setup.ApiPath = "/hc-json";
                //});
            });

            return app;
        }
    }
}
