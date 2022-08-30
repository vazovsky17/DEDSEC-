using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using DEDSEC.WPF.ViewModels.Donations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddOtherViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<HomeViewModel>(s => new HomeViewModel(
                    s.GetRequiredService<DonationGoalMiniViewModel>(),
                    s.GetRequiredService<AccountStore>(),
                    CreateNavigationServiceExtensions.CreateLoginNavigationService(s)));

                services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);

                services.AddSingleton<MainViewModel>();
            });

            return host;
        }

        private static NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<AccountStore>(),
                serviceProvider.GetRequiredService<IAuthenticatorService>(),
                CreateNavigationServiceExtensions.CreateHomeNavigationService(serviceProvider),
                CreateNavigationServiceExtensions.CreateAccountNavigationService(serviceProvider),
                CreateNavigationServiceExtensions.CreateLoginNavigationService(serviceProvider),
                CreateNavigationServiceExtensions.CreateMeetingListingNavigationService(serviceProvider),
                CreateNavigationServiceExtensions.CreatePlayerListingNavigationService(serviceProvider),
                CreateNavigationServiceExtensions.CreateGameListingNavigationService(serviceProvider),
                CreateNavigationServiceExtensions.CreateDonationGoalNavigationService(serviceProvider));
        }
    }
}
