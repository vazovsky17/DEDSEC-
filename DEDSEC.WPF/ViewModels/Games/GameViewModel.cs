using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Games;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GameViewModel : ViewModelBase
    {
        public Game Game { get; private set; }
        public Guid Id => Game.Id;
        public string Name => SetNameDisplay(Game.Name);
        public string Description => SetNameDescription(Game.Description);

        public int MinCountPlayers => Game.MinCountPlayers;
        public int MaxCountPlayers => Game.MaxCountPlayers;
        public string CountPlayersDisplay => SetCountPlayersDisplay(MinCountPlayers, MaxCountPlayers);

        public string LinkHobbyGames => SetLinkDisplay(Game.LinkHobbyGames);
        public List<Review> Reviews => Game.Reviews;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public GameViewModel(Game game,
            GamesStore gamesStore,
            INavigationService editGameNavigationService)
        {
            Game = game;
            EditCommand = new NavigateCommand(editGameNavigationService);
            DeleteCommand = new DeleteGameCommand(Game, gamesStore);
        }

        public void Update(Game game)
        {
            Game = game;

            OnPropertyChanged(nameof(Game));
        }

        /// <summary>
        /// Установка отображаемого названия игры
        /// </summary>
        /// <param name="name">Название, если есть</param>
        /// <returns>Строка с отображаемыем названиием игры</returns>
        private string SetNameDisplay(string? name) => (name != null && name.Length > 0) ? name : "Неизвестно";

        /// <summary>
        /// Установка отображаемого описания игры
        /// </summary>
        /// <param name="description">Описание, если есть</param>
        /// <returns>Строка с отображаемым описанием игры</returns>
        private string SetNameDescription(string? description) => (description != null && description.Length > 0) ? description : "Без описания";

        /// <summary>
        /// Установка отображаемого количества игроков для игры
        /// </summary>
        /// <param name="minCountPlayers">Минимальное количество игроков</param>
        /// <param name="maxCountPlayers">Максимальное количество игроков</param>
        /// <returns>Строка с отображаемым количеством игроков</returns>
        private string SetCountPlayersDisplay(int minCountPlayers, int maxCountPlayers) => minCountPlayers + " - " + maxCountPlayers;

        /// <summary>
        /// Установка отображаемой ссылки на игру
        /// </summary>
        /// <param name="link">Ссылка, если есть</param>
        /// <returns>Строка с отображаемой ссылкой на игру</returns>
        private string SetLinkDisplay(string? link) => (link != null && link.Length > 0) ? link : "Нет ссылки";
    }
}
