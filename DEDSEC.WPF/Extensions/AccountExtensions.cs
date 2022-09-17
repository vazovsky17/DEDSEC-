using DEDSEC.Domain.Models;
using DEDSEC.WPF.ViewModels.Players;
using System.Collections.Generic;
using System.Linq;

namespace DEDSEC.WPF.Extensions
{
    public static class AccountExtensions
    {
        /// <summary>
        /// Установка отображаемого никнейма игрока
        /// </summary>
        /// <param name="account">Аккаунт</param>
        /// <returns>Строка с отображаемым никнеймом</returns>
        public static string SetNicknameDisplay(this Account account)
            => !string.IsNullOrEmpty(account.AccountHolder.Nickname) ? account.AccountHolder.Nickname : "NoName";

        /// <summary>
        /// Установка отображаемого имени игрока
        /// </summary>
        /// <param name="account">Аккаунт</param>
        /// <returns>Строка с отображаемым именем</returns>
        public static string SetNameDisplay(this Account account)
            => !string.IsNullOrEmpty(account.Name) ? account.Name : "Неизвестно";

        /// <summary>
        /// Установка отображаемого возраста
        /// </summary>
        /// <param name="account">Аккаунт</param>
        /// <returns>Строка с отображаемым возрастом</returns>
        public static string SetAgeDisplay(this Account account)
        {
            var age = account.Age;
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
        /// <param name="account">Аккаунт</param>
        /// <returns>Строка с отображаемым описанием игрока о себе</returns>
        public static string SetAboutMeDisplay(this Account account)
            => !string.IsNullOrEmpty(account.AboutMe) ? account.AboutMe : "Не заполнено";

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
