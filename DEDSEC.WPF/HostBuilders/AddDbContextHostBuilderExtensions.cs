using DEDSEC.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DEDSEC.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string conStr = "Server = (localdb)\\MSSQLLocalDB; Database = Dedsec; Trusted_Connection = True";
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(conStr);

                services.AddDbContext<DedsecDbContext>(configureDbContext);
                services.AddSingleton<DedsecDbContextFactory>(new DedsecDbContextFactory(configureDbContext));
            });
            return host;
        }
    }
}
