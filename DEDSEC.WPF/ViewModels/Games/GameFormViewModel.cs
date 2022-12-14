using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GameFormViewModel : ViewModelBase
    {
        #region Properties
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private int _minCountPlayers;
        public int MinCountPlayers
        {
            get
            {
                return _minCountPlayers;
            }
            set
            {
                _minCountPlayers = value;
                OnPropertyChanged(nameof(MinCountPlayers));
            }
        }

        private int _maxCountPlayers;
        public int MaxCountPlayers
        {
            get
            {
                return _maxCountPlayers;
            }
            set
            {
                _maxCountPlayers = value;
                OnPropertyChanged(nameof(MaxCountPlayers));
            }
        }

        private string _linkHobbyGames;
        public string LinkHobbyGames
        {
            get
            {
                return _linkHobbyGames;
            }
            set
            {
                _linkHobbyGames = value;
                OnPropertyChanged(nameof(LinkHobbyGames));
            }
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        public GameFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
