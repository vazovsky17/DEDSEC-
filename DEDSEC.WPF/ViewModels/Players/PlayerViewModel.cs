using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Players;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class PlayerViewModel : ViewModelBase
    {
        public Account Player { get; private set; }
        public Guid Id => Player.Id;
        public User AccountHolder => Player.AccountHolder;
        public string Nickname => Player.SetNicknameDisplay();
        public string Name => Player.SetNameDisplay();
        public string Age => Player.SetAgeDisplay();
        public string AboutMe => Player.SetAboutMeDisplay();
        public bool IsVisited => Player?.IsVisited ?? false;
        public bool IsAdmin => AccountHolder?.IsAdmin ?? false;
        public List<Game> FavoriteGames => Player?.FavoriteGames ?? new();

        public bool IsCurrentAccountAdmin { get; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PlayerViewModel(Account player,
            PlayersStore playersStore,
            bool isCurrentAccountAdmin,
            ModalNavigationStore modalStore,
            IAuthenticatorService authenticatorService,
            INavigationService logoutNavigationService)
        {
            Player = player;
            IsCurrentAccountAdmin = isCurrentAccountAdmin;
            EditCommand = new OpenEditPlayerCommand(this, authenticatorService, playersStore, modalStore);
            DeleteCommand = new DeletePlayerCommand(authenticatorService, logoutNavigationService, playersStore, player);
        }

        public void Update(Account player)
        {
            Player = player;

            OnPropertyChanged(nameof(Player));
        }
    }
}
