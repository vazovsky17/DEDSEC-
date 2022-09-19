using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Games;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GameViewModel : ViewModelBase
    {
        public AccountStore AccountStore { get; }
        public Game Game { get; private set; }

        #region Bindings
        public Guid Id => Game.Id;
        public string Name => Game.SetNameDisplay();
        public string Description => Game.SetNameDescription();
        public string PlayersCount => Game.SetCountPlayersDisplay();
        public string LinkHobbyGames => Game.SetLinkDisplay();
        public bool IsFavorite => Game.IsFavoriteGame(FavoriteGames);
        public bool IsUnfavorite => !Game.IsFavoriteGame(FavoriteGames);
        #endregion

        #region Account
        public Account CurrentAccount => AccountStore.CurrentAccount;
        public List<Game> FavoriteGames => CurrentAccount.FavoriteGames ?? new();
        public bool IsAdmin => CurrentAccount.AccountHolder?.IsAdmin ?? false;
        #endregion

        #region Commands
        public ICommand AddToFavoriteCommand { get; }
        public ICommand DeleteFromFavoriteCommand { get; }
        public ICommand ShowCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        public GameViewModel(Game game,
            GamesStore gamesStore,
            AccountStore accountStore,
            IAuthenticatorService authenticatorService,
            ModalNavigationStore modalNavigationStore)
        {
            Game = game;
            AccountStore = accountStore;
            AddToFavoriteCommand = new AddToFavoritesGamesCommand(game, gamesStore, authenticatorService);
            DeleteFromFavoriteCommand = new DeleteFromFavoriteGamesCommand(game, gamesStore, authenticatorService);
            ShowCommand = new ShowGameCommand(game, accountStore, modalNavigationStore);
            EditCommand = new OpenEditGameCommand(this, accountStore, gamesStore, modalNavigationStore);
            DeleteCommand = new DeleteGameCommand(gamesStore, accountStore, game);
        }

        public void UpdateIsFavorite()
        {
            OnPropertyChanged(nameof(CurrentAccount));
            OnPropertyChanged(nameof(FavoriteGames));
            OnPropertyChanged(nameof(IsFavorite));
            OnPropertyChanged(nameof(IsUnfavorite));
        }

        public void Update(Game game)
        {
            Game = game;

            OnPropertyChanged(nameof(Game));
            UpdateIsFavorite();
        }
    }
}
