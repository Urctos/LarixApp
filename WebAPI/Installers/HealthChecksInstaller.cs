
using Infrastructure.Data;

namespace WebAPI.Installers
{
    public class HealthChecksInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<LarixContext>("Database");

            services.AddHealthChecksUI()
                .AddInMemoryStorage();
                
        }
    }
}
