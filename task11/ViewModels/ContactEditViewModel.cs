using System.Windows.Input;
using task11.Models;
using task11.Services;

namespace task11.ViewModels
{
    public class ContactEditViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigation;
        private Contact _contact = null!;

        public string EditName
        {
            get => _contact?.Name ?? "";
            set { if (_contact != null) { _contact.Name = value; OnPropertyChanged(); } }
        }

        public string EditPhone
        {
            get => _contact?.Phone ?? "";
            set { if (_contact != null) { _contact.Phone = value; OnPropertyChanged(); } }
        }

        public ICommand SaveCommand { get; }

        public ContactEditViewModel(INavigationService navigation)
        {
            _navigation = navigation;

            SaveCommand = new RelayCommand(() => _navigation.NavigateTo<ContactsListViewModel>(_contact));
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Contact c)
            {
                _contact = c; 
            }
            else
            {
                _contact = new Contact();
            }

            OnPropertyChanged(nameof(EditName));
            OnPropertyChanged(nameof(EditPhone));
        }
    }
}