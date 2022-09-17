using DEDSEC.Domain.Models;
using DEDSEC.WPF.ViewModels.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DEDSEC.WPF.Extensions
{
    public static class PlayerExtensions
    {
        /// <summary>
        /// Установка отображаемого никнейма игрока
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <returns>Строка с отображаемым никнеймом</returns>
        public static string SetNicknameDisplay(this Account player)
        {
            var randomList = new List<string>() { "Unknown", "Strange", "Alien" };

            if (!string.IsNullOrEmpty(player.AccountHolder.Nickname))
            {
                return player.AccountHolder.Nickname;
            }
            else
            {
                var randomIndex = new Random().Next(randomList.Count - 1);
                return randomList[randomIndex];
            }
        }

        /// <summary>
        /// Установка отображаемого имени игрока
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <returns>Строка с отображаемым именем</returns>
        public static string SetNameDisplay(this Account player)
        {
            var randomList = new List<string>() { "Безымянный", "Неизвестный", "Таинственный", "Анонимный", "Скрытный" };

            if (!string.IsNullOrEmpty(player.Name))
            {
                return player.Name;
            }
            else
            {
                var randomIndex = new Random().Next(randomList.Count - 1);
                return randomList[randomIndex];
            }
        }

        public static string SetAgeDisplay(this Account player)
        {
            var age = player.Age;
            return age + " " + PluralizeAge(age); 
        }

        private static string PluralizeAge(int num)
        {
            if (num % 10 == 1 && num != 11)
            {
                return "год";
            }
            else if ((num >= 2 && num <= 4) || (num % 10 <= 4 && num % 10 >= 2))
            {
                return "года";
            }
            else
            {
                return "лет";
            }
        }

        /// <summary>
        /// Установка отображаемого описания игрока о себе
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <returns>Строка с отображаемым описанием игрока о себе</returns>
        public static string SetAboutMeDisplay(this Account player)
        {
            if (!string.IsNullOrEmpty(player.AboutMe))
            {
                return player.AboutMe;
            }
            else
            {
                return $"{player.AccountHolder.Nickname} еще ничего не написал(а) о себе";
            }
        }

        public static string setPlayersViewModelsCountDisplay(this IEnumerable<PlayerViewModel> playerViewModels)
        {
            var count = playerViewModels.Count();
            return count + " " + Pluralize(count);
        }

        private static string Pluralize(int num)
        {
            if (num % 10 == 1 && num != 11)
            {
                return "игрок";
            }
            else if ((num >= 2 && num <= 4) || (num % 10 <= 4 && num % 10 >= 2))
            {
                return "игрока";
            }
            else
            {
                return "игроков";
            }
        }
    }
}
