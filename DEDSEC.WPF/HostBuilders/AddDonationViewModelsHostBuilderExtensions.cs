using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddDonationViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddDonationViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<DonationGoalViewModel>(s => new DonationGoalViewModel(
                    s.GetRequiredService<DonationGoalStore>(),
                    s.GetRequiredService<DonationStore>(),
                    CreateAddDonationNavigationService(s)));

                services.AddTransient<AddDonationViewModel>(s => new AddDonationViewModel(
                    s.GetRequiredService<DonationStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));
            });

            return host;
        }

        private static INavigationService CreateAddDonationNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddDonationViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddDonationViewModel>());
        }
    }
}
