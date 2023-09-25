using SMS.Util;
using SMS.Util.Commands;
using SMS.Util.Services;
using SMS.Util.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SMS.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ICommand HomeViewCommand { get; set; }
        public ICommand DiscoveryViewCommand { get; set; }

        private readonly NavigationStore _navigatonStore;

        public ViewModelBase CurrentViewModel => _navigatonStore.CurrentViewModel;


        public MainViewModel
            (
            NavigationStore navigationStore,
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<DiscoveryViewModel> discoveryNavigationService
            )
        {
            _navigatonStore = navigationStore;
            _navigatonStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            HomeViewCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            DiscoveryViewCommand = new NavigateCommand<DiscoveryViewModel>(discoveryNavigationService);

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
