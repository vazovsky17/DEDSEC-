using System.Windows.Input;
using System;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingFormViewModel : ViewModelBase
    {
        #region Properties
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
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

        private DateTime _dateBegin;
        public DateTime DateBegin
        {
            get
            {
                return _dateBegin;
            }
            set
            {
                _dateBegin = value;
                OnPropertyChanged(nameof(DateBegin));
            }
        }

        private TimeSpan _timeBegin;
        public TimeSpan TimeBegin
        {
            get
            {
                return _timeBegin;
            }
            set
            {
                _timeBegin = value;
                OnPropertyChanged(nameof(TimeBegin));
            }
        }

        private DateTime _dateEnd;
        public DateTime DateEnd
        {
            get
            {
                return _dateEnd;
            }
            set
            {
                _dateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }

        private TimeSpan _timeEnd;
        public TimeSpan TimeEnd
        {
            get
            {
                return _timeEnd;
            }
            set
            {
                _timeEnd = value;
                OnPropertyChanged(nameof(TimeEnd));
            }
        }

        private int _maxCountVisitors;
        public int MaxCountVisitors
        {
            get
            {
                return _maxCountVisitors;
            }
            set
            {
                _maxCountVisitors = value;
                OnPropertyChanged(nameof(MaxCountVisitors));
            }
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        public MeetingFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
