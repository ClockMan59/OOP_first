using System.Windows;
using System.Windows.Input;
using task12.Models;
using task12.Services;

namespace task12.ViewModels
{
    public class ContactEditViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigation;
        private readonly PhoneBookDbMinaev2307d2Context _context;
        private Contact _contact = null!;

        public string EditName
        {
            get => _contact?.Name ?? string.Empty;
            set
            {
                if (_contact is not null && _contact.Name != value)
                {
                    _contact.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EditPhone
        {
            get => _contact?.Phone ?? string.Empty;
            set
            {
                if (_contact is not null && _contact.Phone != value)
                {
                    _contact.Phone = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }

        public ContactEditViewModel(INavigationService navigation, PhoneBookDbMinaev2307d2Context context)
        {
            _navigation = navigation;
            _context = context;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Contact contact)
            {
                _contact = contact;
            }
            else
            {
                _contact = new Contact();
            }

            OnPropertyChanged(nameof(EditName));
            OnPropertyChanged(nameof(EditPhone));
        }

        private void Save()
        {
            try
            {
                if (_contact.Id == 0)
                {
                    _context.Contacts.Add(_contact);
                }

                _context.SaveChanges();
                _navigation.NavigateTo<ContactsListViewModel>();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось сохранить контакт: {ex.Message}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private bool CanSave() =>
            !string.IsNullOrWhiteSpace(EditName) &&
            !string.IsNullOrWhiteSpace(EditPhone);
    }
}
