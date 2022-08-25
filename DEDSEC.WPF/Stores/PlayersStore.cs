using System;

namespace DEDSEC.WPF.Stores
{
    public class PlayersStore
    {
        public event Action<string> PlayerAdded;

        public void AddPlayer(string name)
        {
            PlayerAdded?.Invoke(name);
        }
    }
}
