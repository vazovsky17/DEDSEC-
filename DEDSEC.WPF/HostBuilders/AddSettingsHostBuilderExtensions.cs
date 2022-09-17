using DEDSEC.WPF.Components.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddSettingsHostBuilderExtensions
    {
        public static IHostBuilder AddSettings(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<GlobalLogic>();
                services.AddSingleton<GlobalSettings>();
            });
            return host;
        }
    }
}
