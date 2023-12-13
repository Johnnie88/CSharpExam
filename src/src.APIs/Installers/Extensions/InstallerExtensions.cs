using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace src.APIs.Installers.Extensions
{
    public static class InstallerExtensions
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
        {
            List<IInstaller> installers = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(x => x.InstallServices(services, configuration));
        }
    }
}