using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Accounts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddAccountViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddAccountViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                    s.GetRequiredService<IDataService<Account>>(),
                    s.GetRequiredService<AccountStore>(),
                    CreateNavigationServiceExtensions.CreateEditAccountNavigationService(s),
                    CreateNavigationServiceExtensions.CreateHomeNavigationService(s)));
                services.AddTransient<EditAccountViewModel>(s => new EditAccountViewModel(
                    s.GetRequiredService<IDataService<Account>>(),
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));
            });

            return host;
        }
    }
}
