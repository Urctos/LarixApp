
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<LarixContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("LarixDB")));
        }
    }
}
