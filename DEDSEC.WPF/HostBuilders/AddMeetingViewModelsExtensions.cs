using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddMeetingViewModelsExtensions
    {
        public static IHostBuilder AddMeetingViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<AddMeetingViewModel>(s => new AddMeetingViewModel(
                    s.GetRequiredService<IDataService<Meeting>>(),
                    s.GetRequiredService<MeetingsStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<MeetingListingViewModel>(s => new MeetingListingViewModel(
                    s.GetRequiredService<IDataService<Meeting>>(),
                    s.GetRequiredService<MeetingsStore>(),
                    CreateNavigationServiceExtensions.CreateAddMeetingNavigationService(s)));
            });

            return host;
        }
    }
}
