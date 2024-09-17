using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddScoped<IDoorRepository, DoorRepository>();
            services.AddScoped<IGlassTypeRepository, GlassTypeRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            return services;
        }
    }
}
