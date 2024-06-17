
using Application;
using Application.Interfaceas;
using Application.Mappings;
using Application.Services;
using Application.Validators;
using Asp.Versioning;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using WebAPI.MIddelwares;

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


            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblyContaining<CreateDoorDtoValidator>();
                });
            services.AddScoped<ErrorHandlingMiddelware>();
        }
    }
}
