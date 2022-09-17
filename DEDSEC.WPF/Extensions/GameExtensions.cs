using DEDSEC.Domain.Models;
using System.Collections.Generic;

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
            => !string.IsNullOrEmpty(game.Description) ? game.Description: "Без описания";

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

    }
}
