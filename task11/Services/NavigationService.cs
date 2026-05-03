using Microsoft.Extensions.DependencyInjection;
using System;
using task11.ViewModels;

namespace task11.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private object? _currentViewModel;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object? CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class
        {
            var vm = _serviceProvider.GetRequiredService<TViewModel>();

            if (vm is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(parameter);
            }

            CurrentViewModel = vm;
        }
    }
}