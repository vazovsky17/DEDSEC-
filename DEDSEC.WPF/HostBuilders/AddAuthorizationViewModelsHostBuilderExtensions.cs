﻿using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.ViewModels.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DEDSEC.WPF.Services.Authenticator;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddAuthorizationViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddAuthorizaionViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<LoginViewModel>(CreateLoginViewModel);
                services.AddTransient<RegisterViewModel>(CreateRegisterViewModel);
            });
            return host;
        }

        public static LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateNavigationServiceExtensions.CreateAccountNavigationService(serviceProvider));
            return new(
                serviceProvider.GetRequiredService<IAuthenticatorService>(),
                navigationService,
                CreateNavigationServiceExtensions.CreateRegisterNavigationService(serviceProvider));
        }

        public static RegisterViewModel CreateRegisterViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateNavigationServiceExtensions.CreateAccountNavigationService(serviceProvider));
            return new(
                serviceProvider.GetRequiredService<IAuthenticatorService>(),
                navigationService,
                CreateNavigationServiceExtensions.CreateLoginNavigationService(serviceProvider));
        }
    }
}
