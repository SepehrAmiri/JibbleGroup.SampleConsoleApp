using JibbleGroup.SampleConsoleApp.Application.Person.Commands;
using JibbleGroup.SampleConsoleApp.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using JibbleGroup.SampleConsoleApp.Domain;
using JibbleGroup.SampleConsoleApp.Application;
using JibbleGroup.SampleConsoleApp.Infrastructure;
using JibbleGroup.SampleConsoleApp.Presentation;

namespace JibbleGroup.SampleConsoleApp.Presentation
{
    internal class Program
    {        
        static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);

            await hostBuilder.RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostingContext, services) =>
                {
                    services.AddDomain();
                    services.AddApplication();
                    services.AddInfrastructure();
                    services.AddPresentation();
                });
        }
    }
}