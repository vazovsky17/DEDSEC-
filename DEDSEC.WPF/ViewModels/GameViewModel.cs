using DEDSEC.Domain.Models;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public Game Game { get; private set; }
        public Guid Id => Game.Id;
        public string Name => Game.Name;
        public string Description => Game.Description;
        public int MinCountPlayers => Game.MinCountPlayers;
        public int MaxCountPlayers => Game.MaxCountPlayers;
        public string LinkHobbyGames => Game.LinkHobbyGames;
        public List<Review> Reviews => Game.Reviews;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public GameViewModel(Game game, GamesStore gamesStore, ModalNavigationStore modalNavigationStore)
        {
            Game = game;
        }

        public void Update(Game game)
        {
            Game = game;

            OnPropertyChanged(nameof(Game));
        }
    }
}
