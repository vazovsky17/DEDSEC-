﻿using DEDSEC.WPF.Services.Navigation;
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
                services.AddTransient<AddMeetingViewModel>(s => new AddMeetingViewModel(
                    s.GetRequiredService<MeetingsStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<MeetingListingViewModel>(s => new MeetingListingViewModel(
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<MeetingsStore>(),
                    CreateNavigationServiceExtensions.CreateAddMeetingNavigationService(s)));
            });

            return host;
        }
    }
}
