using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Meetings
{
    public class DeleteMeetingCommand : AsyncCommandBase
    {
        private readonly MeetingsStore _meetingsStore;
        private readonly Meeting _meeting;

        public DeleteMeetingCommand(MeetingsStore meetingsStore,
            Meeting meeting
            )
        {
            _meetingsStore = meetingsStore;
            _meeting = meeting;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _meetingsStore.Delete(_meeting);
        }
    }
}
