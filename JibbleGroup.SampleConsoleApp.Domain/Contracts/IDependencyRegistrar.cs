using Microsoft.Extensions.DependencyInjection;

namespace JibbleGroup.SampleConsoleApp.Domain.Contracts
{
    public interface IDependencyRegistrar
    {
        void ConfigureServices(IServiceCollection services);
    }
}
