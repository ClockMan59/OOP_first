using System.Windows.Input;
using task11.Services;

namespace task11.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public INavigationService NavigationService { get; }

        public ICommand ShowContactsCommand { get; }
        public ICommand ShowAboutCommand { get; }

        public MainWindowViewModel(INavigationService navigation)
        {
            NavigationService = navigation;

            ShowContactsCommand = new RelayCommand(() => NavigationService.NavigateTo<ContactsListViewModel>());
            ShowAboutCommand = new RelayCommand(() => NavigationService.NavigateTo<AboutViewModel>());

            NavigationService.NavigateTo<ContactsListViewModel>();
        }
    }
}