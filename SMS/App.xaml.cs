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
using LiveChartsCore;

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

            LiveCharts.Configure(config =>
            config
                // you can override the theme 
                // .AddDarkTheme()  

                // In case you need a non-Latin based font, you must register a typeface for SkiaSharp
                //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('汉')) // <- Chinese 
                //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('あ')) // <- Japanese 
                //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('헬')) // <- Korean 
                //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('Ж'))  // <- Russian 

                //.HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('أ'))  // <- Arabic 
                //.UseRightToLeftSettings() // Enables right to left tooltips 

                // finally register your own mappers
                // you can learn more about mappers at:
                // https://livecharts.dev/docs/wpf/2.0.0-rc1/Overview.Mappers
                .HasMap<City>((city, point) =>
                {
                    // here we use the index as X, and the population as Y 
                    point.Coordinate = new(point.Index, city.Population);
                })
            // .HasMap<Foo>( .... ) 
            // .HasMap<Bar>( .... ) 
            );
        }

        public record City(string Name, double Population);
    
    }
}
