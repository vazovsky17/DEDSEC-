using DEDSEC.Domain.Models;
using System.Collections.Generic;
using System;

namespace DEDSEC.WPF.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public Game Game { get; }
        public Guid Id => Game.Id;
        public string Name => Game.Name;
        public string Description => Game.Description;
        public int MinCountPlayers => Game.MinCountPlayers;
        public int MaxCountPlayers => Game.MaxCountPlayers;
        public string LinkHobbyGames => Game.LinkHobbyGames;
        public List<Review> Reviews => Game.Reviews;

        public GameViewModel(Game game)
        {
            Game = game;
        }
    }
}
