
using Application;
using Application.Interfaceas;
using Application.Mappings;
using Application.Services;
using Asp.Versioning;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddApplication();
            services.AddInfrastructure();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = new[] { new CultureInfo("en-US") };
                options.SupportedUICultures = new[] { new CultureInfo("en-US") };
            });

            services.AddControllers();

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
        }
    }
}
