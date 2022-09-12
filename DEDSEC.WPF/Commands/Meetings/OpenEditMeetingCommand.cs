using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Meetings;

namespace DEDSEC.WPF.Commands.Meetings
{
    public class OpenEditMeetingCommand : CommandBase
    {
        private readonly MeetingViewModel _meetingViewModel;
        private readonly MeetingsStore _meetingsStore;
        private readonly ModalNavigationStore _modalStore;

        public OpenEditMeetingCommand(MeetingViewModel meetingViewModel, 
            MeetingsStore meetingsStore, 
            ModalNavigationStore modalStore)
        {
            _meetingViewModel = meetingViewModel;
            _meetingsStore = meetingsStore;
            _modalStore = modalStore;
        }

        public override void Execute(object parameter)
        {
            Meeting meeting = _meetingViewModel.Meeting;

            EditMeetingViewModel editMeetingViewModel = new EditMeetingViewModel(
                meeting, _meetingsStore, _modalStore);
            _modalStore.CurrentViewModel = editMeetingViewModel;
        }
    }
}
