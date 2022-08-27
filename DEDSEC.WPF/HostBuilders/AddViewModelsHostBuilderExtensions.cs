using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services;
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
                services.AddTransient<HomeViewModel>(s => new HomeViewModel(CreateLoginNavigationService(s)));

                services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                    s.GetRequiredService<AccountStore>(),
                    CreateHomeNavigationService(s)));

                services.AddTransient<LoginViewModel>(CreateLoginViewModel);

                services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);

                services.AddSingleton<MainViewModel>();
            });

            return host;
        }

        private static NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider),
                CreateLoginNavigationService(serviceProvider),
                CreateMeetingListingNavigationService(serviceProvider),
                CreatePlayerListingNavigationService(serviceProvider),
                CreateGameListingNavigationService(serviceProvider),
                CreateDonationGoalNavigationService(serviceProvider));
        }

        private static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private static INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                 serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateAccountNavigationService(serviceProvider));
            return new LoginViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                serviceProvider.GetRequiredService<IDataService<Account>>(),
                navigationService);
        }

        private static INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private static INavigationService CreateMeetingListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MeetingListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MeetingListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private static INavigationService CreatePlayerListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<PlayerListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PlayerListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private static INavigationService CreateDonationGoalNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<DonationGoalViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<DonationGoalViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private static INavigationService CreateGameListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<GameListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<GameListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
    }
}
