using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Meetings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddMeetingViewModelsExtensions
    {
        public static IHostBuilder AddMeetingViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<AddMeetingViewModel>(s => new(
                    s.GetRequiredService<MeetingsStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<MeetingListingViewModel>(s => new(
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<MeetingsStore>(),
                    s.GetRequiredService<ModalNavigationStore>(),
                    CreateNavigationServiceExtensions.CreateAddMeetingNavigationService(s)));
            });

            return host;
        }
    }
}
