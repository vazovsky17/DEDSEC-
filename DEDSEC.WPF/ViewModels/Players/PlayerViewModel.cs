using DEDSEC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml.Linq;

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
        public List<Game> FavoriteGames => Player?.FavoriteGames ?? new List<Game>();

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public PlayerViewModel(Account player)
        {
            Player = player;
        }

        public void Update(Account player)
        {
            Player = player;

            OnPropertyChanged(nameof(Player));
        }

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
