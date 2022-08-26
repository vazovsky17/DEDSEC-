using DEDSEC.Domain.Models;
using System.Collections.Generic;
using System;

namespace DEDSEC.WPF.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public Account Account { get;  }
        public Guid Id => Account.Id;
        public User AccountHolder => Account.AccountHolder;
        public string Name => Account.Name;
        public int Age => Account.Age;
        public string AboutMe => Account.AboutMe;
        public bool IsVisited => Account.IsVisited;
        public List<Game> FavoriteGames => Account.FavoriteGames;

        public PlayerViewModel(Account account)
        {
            Account = account;
        }
    }
}
