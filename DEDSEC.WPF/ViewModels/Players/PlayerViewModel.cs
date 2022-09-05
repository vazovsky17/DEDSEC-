using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Players;
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
        public string Nickname => SetNicknameDisplay(AccountHolder?.Nickname);
        public string Name => SetNameDisplay(Player.Name);
        public int Age => Player?.Age ?? 0;
        public string AboutMe => SetAboutMeDisplay(Player.AboutMe);
        public bool IsVisited => Player?.IsVisited ?? false;
        public bool IsAdmin => AccountHolder?.IsAdmin ?? false;
        public List<Game> FavoriteGames => Player?.FavoriteGames ?? new();

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PlayerViewModel(Account player,
            PlayersStore playersStore,
            IAuthenticatorService authenticatorService,
            INavigationService logoutNavigationService,
            INavigationService editPlayerNavigationService)
        {
            Player = player;
            EditCommand = new NavigateCommand(editPlayerNavigationService);
            DeleteCommand = new DeletePlayerCommand(authenticatorService, logoutNavigationService, playersStore, player);
        }

        public void Update(Account player)
        {
            Player = player;

            OnPropertyChanged(nameof(Player));
        }

        /// <summary>
        /// Установка отображаемого никнейма игрока
        /// </summary>
        /// <param name="nickname">Никнейм, если есть</param>
        /// <returns>Строка с отображаемым никнеймом</returns>
        private string SetNicknameDisplay(string? nickname)
        {
            var randomList = new List<string>() { "Unknown", "Strange", "Alien" };

            if (nickname != null && nickname.Length > 0)
            {
                return nickname;
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
        /// <param name="name">Имя, если есть</param>
        /// <returns>Строка с отображаемым именем</returns>
        private string SetNameDisplay(string? name)
        {
            var randomList = new List<string>() { "Безымянный", "Неизвестный", "Таинственный", "Анонимный", "Скрытный" };

            if (name != null && name.Length > 0)
            {
                return name;
            }
            else
            {
                var randomIndex = new Random().Next(randomList.Count - 1);
                return randomList[randomIndex];
            }
        }

        /// <summary>
        /// Установка отображаемого описания игрока о себе
        /// </summary>
        /// <param name="aboutMe">Описание, если есть</param>
        /// <returns>Строка с отображаемым описанием игрока о себе</returns>
        private string SetAboutMeDisplay(string? aboutMe)
        {
            if (aboutMe != null && aboutMe.Length > 0)
            {
                return aboutMe;
            }
            else
            {
                return $"{Nickname} еще ничего не написал(а) о себе";
            }
        }
    }
}
