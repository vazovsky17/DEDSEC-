using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.EntityFramework.Services;
using DEDSEC.WPF.Services;
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
                services.AddSingleton<IAuthenticatorService, AuthenticatorService>();
                services.AddSingleton<INavigationService>(s => CreateNavigationServiceExtensions.CreateHomeNavigationService(s));
                services.AddSingleton<CloseModalNavigationService>();

                services.AddSingleton<IAccountService, AccountDataService>();
                services.AddSingleton<IDataService<Account>, AccountDataService>();
                services.AddSingleton<IDataService<Donation>, GenericDataService<Donation>>();
                services.AddSingleton<IDataService<DonationGoal>, GenericDataService<DonationGoal>>();
                services.AddSingleton<IDataService<Game>, GenericDataService<Game>>();
                services.AddSingleton<IDataService<Meeting>, GenericDataService<Meeting>>();
                services.AddSingleton<IDataService<Review>, GenericDataService<Review>>();
                services.AddSingleton<IDataService<User>, GenericDataService<User>>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
            });

            return host;
        }
    }
}
