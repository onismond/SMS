using Microsoft.Extensions.Hosting;
using SMS.Model.Db;
using SMS.Util.Services;
using SMS.Util;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using SMS.Util.Network;
using SMS.Util.Stores;
using Microsoft.EntityFrameworkCore;
using SMS.Views;

namespace SMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((hostContext, services) =>
                {
                    //string connectionString = hostContext.Configuration.GetConnectionString("Default");

                    //bool isEndToEndTest = Environment.GetCommandLineArgs().Any(a => a == "E2E");

                    //if (!isEndToEndTest)
                    //{
                    //    string connectionString = hostContext.Configuration.GetConnectionString("Default");
                    //    services.AddSingleton<IModernDbContextFactory>(new ModernDbContextFactory(connectionString));
                    //}
                    //else
                    //{
                    //    services.AddSingleton<IModernDbContextFactory>(new InMemoryModernDbContextFactory());
                    //}

                    //string connectionString = hostContext.Configuration.GetConnectionString("Default");  

                    services.AddSingleton<HttpClient>();

                    services.AddSingleton<MyApi>();

                    services.AddSingleton(new AppDbContextFactory("Data Source = modern.db"));

                    services.AddSingleton<AppDbContext>(s => s.GetRequiredService<AppDbContextFactory>().CreateDbContext());

                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            /*MainWindow = _host.Services.GetRequiredService<HomeWindow>();
            MainWindow.Show();
            Task.Delay(2000);*/

            AppDbContextFactory appDbContextFactory = _host.Services.GetRequiredService<AppDbContextFactory>();
            using (AppDbContext dbContext = appDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            NavigationService<HomeViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<HomeViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
