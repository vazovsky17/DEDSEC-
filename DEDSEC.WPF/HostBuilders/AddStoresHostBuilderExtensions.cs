using DEDSEC.WPF.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<AccountStore>();
                services.AddSingleton<MeetingsStore>();
                services.AddSingleton<PlayersStore>();
                services.AddSingleton<GamesStore>();
                services.AddSingleton<DonationGoalStore>();
                services.AddSingleton<DonationsStore>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ModalNavigationStore>();
            });

            return host;
        }
    }
}
