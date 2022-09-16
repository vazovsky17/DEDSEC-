﻿using DEDSEC.Domain.Models;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System.Collections.Generic;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountViewModel : ViewModelBase
    {
        public AccountStore AccountStore { get; private set; }
        public Account Account => AccountStore.CurrentAccount;
        public string Nickname => !string.IsNullOrEmpty(Account.AccountHolder.Nickname) ? Account.AccountHolder.Nickname : "Неизвестно";
        public string Name => !string.IsNullOrEmpty(Account?.Name) ? Account.Name : "Неизестно";
        public int Age => Account?.Age ?? 0;
        public string AboutMe => !string.IsNullOrEmpty(Account?.AboutMe) ? Account.AboutMe : "Не заполнено";
        public bool IsVisited => Account?.IsVisited ?? false;
        public List<Game> FavoriteGames => Account?.FavoriteGames ?? new();
        public bool HasFavoriteGames => FavoriteGames.Count > 0;

        public AccountViewModel(AccountStore accountStore)
        {
            AccountStore = accountStore;

            AccountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Account));
        }

        public override void Dispose()
        {
            AccountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
