using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using DEDSEC.WPF.ViewModels.Accounts;
using DEDSEC.WPF.ViewModels.Authorization;
using DEDSEC.WPF.ViewModels.Donations.Donations;
using DEDSEC.WPF.ViewModels.Donations.DonationGoals;
using DEDSEC.WPF.ViewModels.Games;
using DEDSEC.WPF.ViewModels.Meetings;
using DEDSEC.WPF.ViewModels.Players;
using Microsoft.Extensions.DependencyInjection;
using System;
using DEDSEC.WPF.ViewModels.Donations;

namespace DEDSEC.WPF.HostBuilders
{
    public static class CreateNavigationServiceExtensions
    {
        #region Authorization
        public static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        public static INavigationService CreateRegisterNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<RegisterViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<RegisterViewModel>());
        }
        #endregion

        #region Account
        public static INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountScreenViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountScreenViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateEditAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<EditAccountViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<EditAccountViewModel>());
        }

        #endregion

        #region Game
        public static INavigationService CreateGameListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<GamesScreenViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<GamesScreenViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateAddGameNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddGameViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddGameViewModel>());
        }
        #endregion

        #region Meeting
        public static INavigationService CreateMeetingListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MeetingsScreenViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MeetingsScreenViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateAddMeetingNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddMeetingViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddMeetingViewModel>());
        }
        #endregion

        #region Player
        public static INavigationService CreatePlayerListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<PlayersScreenViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PlayersScreenViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateAddPlayerNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddPlayerViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddPlayerViewModel>());
        }

        public static INavigationService CreateEditPlayerNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<EditPlayerViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<EditPlayerViewModel>());
        }
        #endregion

        #region Donation
        public static INavigationService CreateDonationGoalNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<DonationsScreenViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<DonationsScreenViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        public static INavigationService CreateAddDonationNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddDonationViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddDonationViewModel>());
        }

        public static INavigationService CreateAddDonationGoalNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddDonationGoalViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddDonationGoalViewModel>());
        }
        #endregion

        #region Other
        public static INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                 serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        #endregion
    }
}
