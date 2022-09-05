using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddGameViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddGameViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<AddGameViewModel>(s => new(
                    s.GetRequiredService<GamesStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<GameListingViewModel>(s => new(
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<GamesStore>(),
                    CreateNavigationServiceExtensions.CreateAddGameNavigationService(s),
                    CreateNavigationServiceExtensions.CreateEditGameNavigationService(s)));
            });

            return host;
        }
    }
}
