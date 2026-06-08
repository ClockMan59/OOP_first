using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using task12.Models;
using task12.Services;

namespace task12.ViewModels
{
    public class ContactsListViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigation;
        private readonly PhoneBookDbMinaev2307d2Context _context;

        public ObservableCollection<Contact> Contacts { get; } = new();

        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ContactsListViewModel(INavigationService navigation, PhoneBookDbMinaev2307d2Context context)
        {
            _navigation = navigation;
            _context = context;

            AddCommand = new RelayCommand(() => _navigation.NavigateTo<ContactEditViewModel>());
            EditCommand = new RelayCommand(EditContact, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteContact, CanEditOrDelete);
        }

        public void OnNavigatedTo(object? parameter)
        {
            RefreshContacts();
        }

        private void RefreshContacts()
        {
            _context.ChangeTracker.Clear();

            Contacts.Clear();
            foreach (var contact in _context.Contacts.OrderBy(c => c.Name).ToList())
            {
                Contacts.Add(contact);
            }

            SelectedContact = null;
        }

        private void EditContact()
        {
            if (SelectedContact is not null)
            {
                _navigation.NavigateTo<ContactEditViewModel>(SelectedContact);
            }
        }

        private void DeleteContact()
        {
            if (SelectedContact is null)
            {
                return;
            }

            var contactToDelete = SelectedContact;
            var result = MessageBox.Show(
                $"Удалить контакт \"{contactToDelete.Name}\"?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                _context.Contacts.Remove(contactToDelete);
                _context.SaveChanges();
                RefreshContacts();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось удалить контакт: {ex.Message}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private bool CanEditOrDelete() => SelectedContact is not null;
    }
}
