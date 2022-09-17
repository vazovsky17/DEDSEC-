using DEDSEC.Domain.Models;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Stores;
using System.Collections.Generic;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountViewModel : ViewModelBase
    {
        public AccountStore AccountStore { get; private set; }
        public Account Account => AccountStore.CurrentAccount;
        public string Nickname => Account.SetNicknameDisplay();
        public string Name => Account.SetNameDisplay();
        public string Age => Account.SetAgeDisplay();
        public string AboutMe => Account.SetAboutMeDisplay();
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
