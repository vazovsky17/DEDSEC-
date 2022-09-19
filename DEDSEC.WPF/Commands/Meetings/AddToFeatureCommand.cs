using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Meetings
{
    public class AddToFeatureCommand : AsyncCommandBase
    {
        private readonly Meeting _meeting;
        private readonly MeetingsStore _meetingsStore;
        private readonly IAuthenticatorService _authenticatorService;

        public AddToFeatureCommand(Meeting meeting,
            MeetingsStore meetingsStore,
            IAuthenticatorService authenticatorService)
        {
            _meeting = meeting;
            _meetingsStore = meetingsStore;
            _authenticatorService = authenticatorService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = _authenticatorService.CurrentAccount;
            if (account != null)
            {
                await _meetingsStore.AddToFeature(_meeting);
            }
        }
    }
}
