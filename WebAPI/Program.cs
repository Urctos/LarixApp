using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WebAPI.Installers;
using WebAPI.MIddelwares;
using NLog;
using NLog.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseNLog();
        builder.Services.InstallServicesInAssembly(builder.Configuration);

        var app = builder.Build();
;

        app.UseRouting();
        app.UseMiddleware<ErrorHandlingMiddelware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
        }

        app.MapControllers();
        app.MapHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecksUI();

        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

        try
        {
            //throw new Exception("Fatal error!");
            app.Run();
        }
        catch (Exception ex)
        {
            logger.Fatal(ex, "Application stopped because of exception");
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }
}
