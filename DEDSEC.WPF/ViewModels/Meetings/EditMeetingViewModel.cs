using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Meetings;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Meetings
{
    public class EditMeetingViewModel : ViewModelBase
    {
        public Meeting Meeting { get; }
        public MeetingFormViewModel MeetingFormViewModel { get; }

        public EditMeetingViewModel(Meeting meeting,
            MeetingsStore meetingsStore,
            ModalNavigationStore modalStore)
        {
            Meeting = meeting;

            var SubmitCommand = new EditMeetingCommand(this, meetingsStore, modalStore);
            var CancelCommand = new CloseModalCommand(modalStore);

            MeetingFormViewModel = new MeetingFormViewModel(SubmitCommand, CancelCommand)
            {
                Title = Meeting.Title ?? string.Empty,
                Description = Meeting.Description ?? string.Empty,
                DateBegin = Meeting.DateBegin.Date,
                TimeBegin = Meeting.DateBegin.TimeOfDay,
                DateEnd = Meeting.DateEnd.Date,
                TimeEnd = Meeting.DateEnd.TimeOfDay,
                MaxCountVisitors = Meeting.MaxCountVisitors
            };
        }
    }
}
