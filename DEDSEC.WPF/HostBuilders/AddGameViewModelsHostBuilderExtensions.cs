using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
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
                services.AddTransient<AddGameViewModel>(s => new AddGameViewModel(
                    s.GetRequiredService<GamesStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<GameListingViewModel>(s => new GameListingViewModel(
                    s.GetRequiredService<GamesStore>(),
                    CreateAddGameNavigationService(s)));
            });

            return host;
        }

        private static INavigationService CreateAddGameNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddGameViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddGameViewModel>());
        }
    }
}
