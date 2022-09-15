using DEDSEC.Domain.Models;
using System.Collections.Generic;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountViewModel : ViewModelBase
    {
        public Account Account { get; private set; }
        public string Nickname => !string.IsNullOrEmpty(Account.AccountHolder.Nickname) ? Account.AccountHolder.Nickname : "Неизвестно";
        public string Name => !string.IsNullOrEmpty(Account?.Name) ? Account.Name : "Неизестно";
        public int Age => Account?.Age ?? 0;
        public string AboutMe => !string.IsNullOrEmpty(Account?.AboutMe) ? Account.AboutMe : "Не заполнено";
        public bool IsVisited => Account?.IsVisited ?? false;
        public List<Game> FavoriteGames => Account?.FavoriteGames ?? new();

        public AccountViewModel(Account account)
        {
            Account = account;
        }

        public void Update(Account account)
        {
            Account = account;

            OnPropertyChanged(nameof(Account));
        }
    }
}
