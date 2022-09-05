﻿using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    s.GetRequiredService<ModalNavigationStore>(),
                    CreateNavigationServiceExtensions.CreateAddGameNavigationService(s)));
            });

            return host;
        }
    }
}
