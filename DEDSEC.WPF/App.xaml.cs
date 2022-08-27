using DEDSEC.EntityFramework;
using DEDSEC.WPF.HostBuilders;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace DEDSEC.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddStores()
                .AddServices()
                .AddAccountViewModels()
                .AddGameViewModels()
                .AddMeetingViewModels()
                .AddDonationViewModels()
                .AddPlayerViewModels()
                .AddOtherViewModels()
                .AddDbContext()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<MainWindow>(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                });   
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            INavigationService initialNavigationService = _host.Services.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            DedsecDbContextFactory contextFactory = _host.Services.GetRequiredService<DedsecDbContextFactory>();
            using (DedsecDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }


            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
