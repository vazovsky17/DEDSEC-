using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Meetings;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Meetings
{
    /// <summary>
    /// Добавление встречи
    /// </summary>
    public class AddMeetingCommand : AsyncCommandBase
    {
        private readonly AddMeetingViewModel _addMeetingViewModel;
        private readonly MeetingsStore _meetingsStore;
        private readonly INavigationService _navigationService;

        public AddMeetingCommand(AddMeetingViewModel addMeetingViewModel,
            MeetingsStore meetingsStore,
            INavigationService navigationService)
        {
            _addMeetingViewModel = addMeetingViewModel;
            _meetingsStore = meetingsStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var meeting = new Meeting()
            {
                Id = Guid.NewGuid(),
                Title = _addMeetingViewModel.MeetingFormViewModel.Title,
                Description = _addMeetingViewModel.MeetingFormViewModel.Description,
                DateBegin = _addMeetingViewModel.MeetingFormViewModel.DateBegin,
                DateEnd = _addMeetingViewModel.MeetingFormViewModel.DateEnd,
                MaxCountVisitors = _addMeetingViewModel.MeetingFormViewModel.MaxCountVisitors
            };
            await _meetingsStore.Add(meeting).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _navigationService.Navigate();
                }
            });
        }
    }
}
