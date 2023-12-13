using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace src.APIs.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}