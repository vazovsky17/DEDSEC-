using DEDSEC.Domain.Models;
using DEDSEC.WPF.ViewModels.Games;
using System.Collections.Generic;
using System.Linq;

namespace DEDSEC.WPF.Extensions
{
    public static class GameExtensions
    {
        /// <summary>
        /// Установка отображаемого названия игры
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Строка с отображаемым названием игры</returns>
        public static string SetNameDisplay(this Game game)
            => !string.IsNullOrEmpty(game.Name) ? game.Name : "Неизвестно";

        /// <summary>
        /// Установка отображаемого описания игры
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Строка с отображаемым описанием игры</returns>
        public static string SetNameDescription(this Game game)
            => !string.IsNullOrEmpty(game.Description) ? game.Description : "Без описания";

        /// <summary>
        /// Установка отображаемого количества игроков для игры
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Строка с отображаемым количеством игроков</returns>
        public static string SetCountPlayersDisplay(this Game game)
            => game.MinCountPlayers + " - " + game.MaxCountPlayers;

        /// <summary>
        /// Установка отображаемой ссылки на игру
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Строка с отображаемой ссылкой на игру</returns>
        public static string SetLinkDisplay(this Game game)
            => !string.IsNullOrEmpty(game.LinkHobbyGames) ? game.LinkHobbyGames : "Нет ссылки";

        /// <summary>
        /// Выявление, есть ли игра в избранном
        /// </summary>
        /// <param name="game">Игра</param>
        /// <param name="favoriteGames">Избранные игры текущего аккаунта</param>
        /// <returns>Является ли игра избранной</returns>
        public static bool IsFavoriteGame(this Game game, List<Game> favoriteGames)
        {
            foreach (var item in favoriteGames)
            {
                if (item.Id == game.Id) return true;
            }
            return false;
        }

        public static string setGameViewModelsCountDisplay(this IEnumerable<GameViewModel> gameViewModels)
        {
            var count = gameViewModels.Count();
            return count + " " + Pluralize(count);
        }

        private static string Pluralize(int num)
        {
            if (num % 10 == 1 && num != 11)
            {
                return "игра";
            }
            else if (( num >= 2 && num <=4) || (num % 10 <= 4 && num % 10 >= 2))
            {
                return "игры";
            }
            else
            {
                return "игр";
            }
        }
    }
}
