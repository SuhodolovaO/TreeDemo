using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDependencies
    {
        public static void ConfigureApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<INodeService, NodeService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IJournalService, JournalService>();
        }
    }
}
