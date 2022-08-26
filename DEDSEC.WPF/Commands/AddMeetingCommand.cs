using DEDSEC.Domain.Models;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System;

namespace DEDSEC.WPF.Commands
{
    public class AddMeetingCommand : CommandBase
    {
        private readonly AddMeetingViewModel _addMeetingViewModel;
        private readonly MeetingsStore _meetingsStore;
        private readonly INavigationService _navigationService;

        public AddMeetingCommand(AddMeetingViewModel addMeetingViewModel, MeetingsStore meetingsStore, INavigationService navigationService)
        {
            _addMeetingViewModel = addMeetingViewModel;
            _meetingsStore = meetingsStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _meetingsStore.AddMeeting(new Meeting(
                 Guid.NewGuid(),
                _addMeetingViewModel.Title,
                _addMeetingViewModel.Description,
                _addMeetingViewModel.DateBegin,
                _addMeetingViewModel.DateEnd,
                _addMeetingViewModel.MaxCountVisitors));
            _navigationService.Navigate();
        }
    }
}
