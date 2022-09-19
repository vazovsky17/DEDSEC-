using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.EntityFramework.Services;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigationService>(s => CreateNavigationServiceExtensions.CreateHomeNavigationService(s));
                services.AddSingleton<CloseModalNavigationService>();

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IAuthenticatorService, AuthenticatorService>();
                services.AddSingleton<IDataService<Account>, AccountDataService>();
                services.AddSingleton<IAccountDataService, AccountDataService>();
                
                services.AddSingleton<IDataService<Game>, GenericDataService<Game>>();
                services.AddSingleton<IDataService<Meeting>, GenericDataService<Meeting>>();
                services.AddSingleton<IDataService<User>, GenericDataService<User>>();
            });

            return host;
        }
    }
}
