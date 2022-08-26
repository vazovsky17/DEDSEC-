﻿using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateMeetingListingCommand{ get; }
        public ICommand NavigatePlayerListingCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsLoggedIn => _accountStore.IsLoggedIn;
        public bool IsUnlogged => !IsLoggedIn;

        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService homeNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService,
            INavigationService meetingListingNavigationService,
            INavigationService playerListingNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigateMeetingListingCommand = new NavigateCommand(meetingListingNavigationService);
            NavigatePlayerListingCommand = new NavigateCommand(playerListingNavigationService);
            LogoutCommand = new LogoutCommand(_accountStore);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsUnlogged));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
