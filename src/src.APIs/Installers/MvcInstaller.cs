using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace src.APIs.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
        }
    }
}