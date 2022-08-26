﻿using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddPlayerViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddPlayerViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<PlayerListingViewModel>(s => new PlayerListingViewModel(
                    s.GetRequiredService<PlayersStore>()));
            });

            return host;
        }
    }
}
