using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMS.Model.Repositories;
using SMS.Util.Services;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Util
{
    public static class ViewModelsHostBuilder
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<Func<HomeViewModel>>((s) => () => s.GetRequiredService<HomeViewModel>());
                services.AddSingleton<NavigationService<HomeViewModel>>();

                services.AddSingleton<DiscoveryViewModel>();
                services.AddSingleton<Func<DiscoveryViewModel>>((s) => () => s.GetRequiredService<DiscoveryViewModel>());
                services.AddSingleton<NavigationService<DiscoveryViewModel>>();

                services.AddSingleton<MainViewModel>();

                services.AddSingleton<HomeRepository>();

            });

            return hostBuilder;
        }

        //private static ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider services)
        //{
        //    return ReservationListingViewModel.LoadViewModel(
        //        services.GetRequiredService<HotelStore>(),
        //        services.GetRequiredService<NavigationService<MakeReservationViewModel>>());
        //}
        //services.AddTransient((s) => CreateReservationListingViewModel(s));

    }
}
