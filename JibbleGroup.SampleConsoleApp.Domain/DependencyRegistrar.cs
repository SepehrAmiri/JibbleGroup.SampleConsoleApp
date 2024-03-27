using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace JibbleGroup.SampleConsoleApp.Domain
{
    public static class DependencyRegistrar 
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {

            return services;
        }
    }
}
