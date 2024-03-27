using JibbleGroup.SampleConsoleApp.Domain.Contracts;
using JibbleGroup.SampleConsoleApp.Domain.Contracts.IRepositories;
using JibbleGroup.SampleConsoleApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JibbleGroup.SampleConsoleApp.Infrastructure
{
    public static class DependencyRegistrar 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
