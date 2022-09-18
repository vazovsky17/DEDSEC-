using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Services;
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
                services.AddTransient<AccountScreenViewModel>(s => new(
                    s.GetRequiredService<IAccountService>(),
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<IAuthenticatorService>(),
                    CreateNavigationServiceExtensions.CreateEditAccountNavigationService(s),
                    CreateNavigationServiceExtensions.CreateHomeNavigationService(s)));
                services.AddTransient<EditAccountViewModel>(s => new(
                    s.GetRequiredService<IAccountService>(),
                    s.GetRequiredService<AccountStore>(),
                    s.GetRequiredService<CloseModalNavigationService>()));
            });

            return host;
        }
    }
}
