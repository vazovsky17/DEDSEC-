using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Players;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddPlayerViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddPlayerViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<PlayerListingViewModel>(s => new PlayerListingViewModel(
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<IAuthenticatorService>(),
                    s.GetRequiredService<PlayersStore>(),
                    CreateNavigationServiceExtensions.CreateAddPlayerNavigationService(s),
                    CreateNavigationServiceExtensions.CreateEditPlayerNavigationService(s)));
            });

            return host;
        }
    }
}
