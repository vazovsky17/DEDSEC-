﻿using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Games;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class EditGameViewModel : ViewModelBase
    {
        public Game Game { get; }
        public GameFormViewModel GameFormViewModel { get; }

        public EditGameViewModel(Game game,
            AccountStore accountStore,
            GamesStore gamesStore,
            ModalNavigationStore modalNavigationStore)
        {
            Game = game;
            var SubmitCommand = new EditGameCommand(this, accountStore, gamesStore, modalNavigationStore);
            var CancelCommand = new CloseModalCommand(modalNavigationStore);

            GameFormViewModel = new GameFormViewModel(SubmitCommand, CancelCommand)
            {
                Name = Game.Name ?? string.Empty,
                Description = Game.Description ?? string.Empty,
                MinCountPlayers = Game.MinCountPlayers,
                MaxCountPlayers = Game.MaxCountPlayers,
                LinkHobbyGames = Game.LinkHobbyGames ?? string.Empty
            };
        }
    }
}
