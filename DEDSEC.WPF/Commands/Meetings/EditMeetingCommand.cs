using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Meetings;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Meetings
{
    public class EditMeetingCommand : AsyncCommandBase
    {
        private readonly EditMeetingViewModel _editMeetingViewModel;
        private readonly MeetingsStore _meetingsStore;
        private readonly ModalNavigationStore _modalStore;

        public EditMeetingCommand(EditMeetingViewModel editMeetingViewModel, MeetingsStore meetingsStore, ModalNavigationStore modalStore)
        {
            _editMeetingViewModel = editMeetingViewModel;
            _meetingsStore = meetingsStore;
            _modalStore = modalStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var meeting = new Meeting()
            {
                Id = _editMeetingViewModel.Meeting.Id,
                Title = _editMeetingViewModel.MeetingFormViewModel.Title,
                Description = _editMeetingViewModel.MeetingFormViewModel.Description,
                DateBegin = _editMeetingViewModel.Meeting.DateBegin,    
                DateEnd = _editMeetingViewModel.Meeting.DateEnd,
                MaxCountVisitors = _editMeetingViewModel.Meeting.MaxCountVisitors
            };

            if(meeting != null)
            {
                await _meetingsStore.Update(meeting).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        _modalStore.Close();
                    }
                });
            }
        }
    }
}
