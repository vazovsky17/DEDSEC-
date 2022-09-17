using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Meetings;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;

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

            MeetingFormViewModel = new MeetingFormViewModel(SubmitCommand, CancelCommand)
            {   
                Title = string.Empty,
                Description = string.Empty,
                DateBegin = System.DateTime.Now,
                DateEnd = System.DateTime.Now,
                MaxCountVisitors = 8
            };
        }
    }
}
