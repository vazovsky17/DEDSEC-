using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Meetings;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class AddMeetingViewModel : ViewModelBase
    {
        public MeetingFormViewModel MeetingFormViewModel { get; }

        public AddMeetingViewModel(MeetingsStore meetingsStore,
            INavigationService closeNavigationService)
        {
            var SubmitCommand = new AddMeetingCommand(this, meetingsStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);

            var dateNow = DateTime.Now;
            var dateStartDefault = dateNow.AddHours(1).AddMinutes(-dateNow.Minute).AddSeconds(-dateNow.Second);
            var dateEndDefault = dateStartDefault.AddHours(1);
            MeetingFormViewModel = new MeetingFormViewModel(SubmitCommand, CancelCommand)
            {

                Title = string.Empty,
                Description = string.Empty,
                DateBegin = dateStartDefault.Date,
                TimeBegin = dateStartDefault.TimeOfDay,
                DateEnd = dateEndDefault.Date,
                TimeEnd = dateEndDefault.TimeOfDay,
                MaxCountVisitors = 8
            };
        }
    }
}
