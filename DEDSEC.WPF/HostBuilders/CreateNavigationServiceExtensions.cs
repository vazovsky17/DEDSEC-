using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using DEDSEC.WPF.ViewModels.Accounts;
using DEDSEC.WPF.ViewModels.Donations;
using DEDSEC.WPF.ViewModels.Games;
using DEDSEC.WPF.ViewModels.Meetings;
using DEDSEC.WPF.ViewModels.Players;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DEDSEC.WPF.HostBuilders
{
    public static class CreateNavigationServiceExtensions
    {
        public static INavigationService CreateEditAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<EditAccountViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<EditAccountViewModel>());
        }

        public static INavigationService CreateAddGameNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddGameViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddGameViewModel>());
        }

        public static INavigationService CreateAddMeetingNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddMeetingViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddMeetingViewModel>());
        }

        public static INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                 serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        public static INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateMeetingListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MeetingListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MeetingListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreatePlayerListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<PlayerListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PlayerListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateDonationGoalNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<DonationGoalViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<DonationGoalViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateAddDonationNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddDonationViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddDonationViewModel>());
        }

        public static INavigationService CreateGameListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<GameListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<GameListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
    }
}
