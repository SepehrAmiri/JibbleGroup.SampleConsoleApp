using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace JibbleGroup.SampleConsoleApp.Presentation
{
    public static class DependencyRegistrar 
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<IHostedService, ConsoleApp>();

            return services;
        }
    }
}
