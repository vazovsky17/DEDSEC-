using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class MeetingListingViewModel : ViewModelBase
    {
        public ICommand AddMeetingCommand { get; }
        private readonly IDataService<Meeting> _dataService;
        private readonly AccountStore _accountStore;
        private readonly MeetingsStore _meetingsStore;

        private IEnumerable<Meeting> _meetings;
        public IEnumerable<Meeting> Meetings
        {
            get
            {
                return _meetings;
            }
            set
            {
                _meetings = value;
                OnPropertyChanged(nameof(Meetings));
            }
        }
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        public MeetingListingViewModel(IDataService<Meeting> dataService, AccountStore accountStore, MeetingsStore meetingsStore, INavigationService addMeetingNavigationService)
        {
            _dataService = dataService;
            _accountStore = accountStore;
            _meetingsStore = meetingsStore;

            AddMeetingCommand = new NavigateCommand(addMeetingNavigationService);

            LoadMeetings();
            _meetingsStore.MeetingAdded += OnMeetingAdded;
        }

        private void OnMeetingAdded(Meeting meeting)
        {
            _meetings.Append(meeting);
        }

        private async void LoadMeetings()
        {
            await _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _meetings = task.Result;
                    OnPropertyChanged(nameof(Meetings));
                }
            });
        }
    }
}
