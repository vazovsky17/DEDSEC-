using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
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

                services.AddTransient<LoginViewModel>(CreateLoginViewModel);

                services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);

                services.AddSingleton<MainViewModel>();
            });

            return host;
        }

        public static LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateNavigationServiceExtensions.CreateAccountNavigationService(serviceProvider));
            return new LoginViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                serviceProvider.GetRequiredService<IDataService<Account>>(),
                navigationService);
        }

        private static NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<AccountStore>(),
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
