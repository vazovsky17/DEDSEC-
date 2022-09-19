using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
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
                services.AddTransient<AddPlayerViewModel>(s => new(
                    s.GetRequiredService<PlayersStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<PlayersScreenViewModel>(s => new(
                    s.GetRequiredService<IAuthenticatorService>(),
                    s.GetRequiredService<PlayersStore>(),
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<ModalNavigationStore>(),
                    CreateNavigationServiceExtensions.CreateAddPlayerNavigationService(s),
                    CreateNavigationServiceExtensions.CreateHomeNavigationService(s)));
            });

            return host;
        }
    }
}
