using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Meetings;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

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
                Title = Meeting.Title,
                Description = Meeting.Description,
                DateBegin = Meeting.DateBegin,
                DateEnd = Meeting.DateEnd,
                MaxCountVisitors = Meeting.MaxCountVisitors
            };
        }
    }
}
