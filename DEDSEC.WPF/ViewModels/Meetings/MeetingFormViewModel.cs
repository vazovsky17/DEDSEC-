using System.Windows.Input;
using System;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class MeetingFormViewModel : ViewModelBase
    {
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MeetingFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
