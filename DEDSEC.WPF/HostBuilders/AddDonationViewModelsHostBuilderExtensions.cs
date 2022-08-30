using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    s.GetRequiredService<AccountStore>(),
                    CreateNavigationServiceExtensions.CreateAddDonationNavigationService(s),
                    CreateNavigationServiceExtensions.CreateAddDonationGoalNavigationService(s),
                    CreateNavigationServiceExtensions.CreateEditDonationGoalNavigationService(s)));

                services.AddTransient<AddDonationViewModel>(s => new AddDonationViewModel(
                    s.GetRequiredService<DonationGoalStore>(),
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));

                services.AddTransient<AddDonationGoalViewModel>(s => new AddDonationGoalViewModel(
                    s.GetRequiredService<DonationGoalStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));
            });

            return host;
        }
    }
}
