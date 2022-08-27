using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.EntityFramework.Services;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
                services.AddSingleton<CloseModalNavigationService>();

                services.AddSingleton<IDataService<Account>, GenericDataService<Account>>();
                services.AddSingleton<IDataService<Donation>, GenericDataService<Donation>>();
                services.AddSingleton<IDataService<DonationGoal>, GenericDataService<DonationGoal>>();
                services.AddSingleton<IDataService<Game>, GenericDataService<Game>>();
                services.AddSingleton<IDataService<Meeting>, GenericDataService<Meeting>>();
                services.AddSingleton<IDataService<Review>, GenericDataService<Review>>();
                services.AddSingleton<IDataService<User>, GenericDataService<User>>();
            });

            return host;
        }

        private static INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                 serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
    }
}
