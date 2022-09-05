using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Meetings
{
    public class DeleteMeetingCommand : AsyncCommandBase
    {
        private readonly Meeting _meeting;
        private readonly MeetingsStore _meetingsStore;

        public DeleteMeetingCommand(Meeting meeting,
            MeetingsStore meetingsStore)
        {
            _meeting = meeting;
            _meetingsStore = meetingsStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _meetingsStore.Delete(_meeting);
        }
    }
}
