using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static void ConfigureInfrastructureDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<Context>(c => c.UseNpgsql(configuration.GetConnectionString("Main")));

            services.AddScoped<INodeRepository, NodeRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
        }
    }
}
