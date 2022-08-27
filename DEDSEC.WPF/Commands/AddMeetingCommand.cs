using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    public class AddMeetingCommand : AsyncCommandBase
    {
        private readonly IDataService<Meeting> _dataService;
        private readonly AddMeetingViewModel _addMeetingViewModel;
        private readonly MeetingsStore _meetingsStore;
        private readonly INavigationService _navigationService;

        public AddMeetingCommand(AddMeetingViewModel addMeetingViewModel, IDataService<Meeting> dataService, MeetingsStore meetingsStore, INavigationService navigationService)
        {
            _addMeetingViewModel = addMeetingViewModel;
            _dataService = dataService;
            _meetingsStore = meetingsStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var meeting = new Meeting()
            {
                Id = Guid.NewGuid(),
                Title = _addMeetingViewModel.Title,
                Description = _addMeetingViewModel.Description,
                DateBegin = _addMeetingViewModel.DateBegin,
                DateEnd = _addMeetingViewModel.DateEnd,
                MaxCountVisitors = _addMeetingViewModel.MaxCountVisitors
            };
            await _dataService.Create(meeting).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _meetingsStore.AddMeeting(meeting);
                    _navigationService.Navigate();
                }
            });
        }
    }
}
