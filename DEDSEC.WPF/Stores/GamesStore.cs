using DEDSEC.Domain.Models;
using System;

namespace DEDSEC.WPF.Stores
{
    public class GamesStore
    {
        public event Action<Game> GameAdded;

        public void AddGame(Game game)
        {
            GameAdded?.Invoke(game);
        }
    }
}
