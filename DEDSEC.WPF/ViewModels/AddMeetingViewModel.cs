﻿using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class AddMeetingViewModel : ViewModelBase
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

        public AddMeetingViewModel(IDataService<Meeting> dataService, MeetingsStore meetingsStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddMeetingCommand(this, dataService, meetingsStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
