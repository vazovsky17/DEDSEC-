using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Meetings;
using System;
using System.Threading.Tasks;
using System.Windows;

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
            var form = _addMeetingViewModel.MeetingFormViewModel;
            MessageBox.Show(form.DateBegin.ToString());
            MessageBox.Show(form.TimeBegin.ToString());
            MessageBox.Show(form.DateEnd.ToString());
            MessageBox.Show(form.TimeEnd.ToString());
            var dateBegin = form.DateBegin.Date.Add(form.TimeBegin);
            var dateEnd = form.DateEnd.Date.Add(form.TimeEnd);
            var meeting = new Meeting()
            {
                Id = Guid.NewGuid(),
                Title = form.Title,
                Description = form.Description,
                DateBegin = dateBegin,
                DateEnd = dateEnd,
                MaxCountVisitors = form.MaxCountVisitors
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
