using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace DEDSEC.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<AccountStore>();
            services.AddSingleton<MeetingsStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(CreateLoginNavigationService(s)));

            services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s)));

            services.AddTransient<LoginViewModel>(CreateLoginViewModel);

            services.AddTransient<MeetingListingViewModel>(s => new MeetingListingViewModel(
                s.GetRequiredService<MeetingsStore>(),
               CreateAddMeetingNavigationService(s)));

            services.AddTransient<AddMeetingViewModel>(s => new AddMeetingViewModel(
                s.GetRequiredService<MeetingsStore>(),
                s.GetRequiredService<CloseModalNavigationService>()));

            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                 serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateAccountNavigationService(serviceProvider));
            return new LoginViewModel(
                serviceProvider.GetRequiredService<AccountStore>(),
                navigationService);
        }

        private INavigationService CreateAddMeetingNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddMeetingViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddMeetingViewModel>());
        }

        private INavigationService CreateMeetingListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MeetingListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MeetingListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateAccountNavigationService(serviceProvider),
                CreateLoginNavigationService(serviceProvider),
                CreateMeetingListingNavigationService(serviceProvider));
        }
    }
}
