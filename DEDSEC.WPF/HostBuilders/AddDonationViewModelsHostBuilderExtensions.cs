using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations.Donations;
using DEDSEC.WPF.ViewModels.Donations.DonationGoals;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DEDSEC.WPF.ViewModels.Donations;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddDonationViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddDonationViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<DonationsScreenViewModel>(s => new(
                    s.GetRequiredService<DonationGoalStore>(),
                    s.GetRequiredService<AccountStore>(),
                    CreateNavigationServiceExtensions.CreateAddDonationNavigationService(s),
                    CreateNavigationServiceExtensions.CreateAddDonationGoalNavigationService(s),
                    s.GetRequiredService<ModalNavigationStore>()));

                services.AddTransient<AddDonationViewModel>(s => new(
                    s.GetRequiredService<DonationGoalStore>(),
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<AddDonationGoalViewModel>(s => new(
                    s.GetRequiredService<DonationGoalStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));
            });

            return host;
        }
    }
}
