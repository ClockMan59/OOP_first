using System.Collections.ObjectModel;
using System.Windows.Input;
using task9.Models;

namespace task9.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<Contact> Contacts { get; } = new();

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string _phone = string.Empty;
        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            AddCommand = new RelayCommand(AddContact, CanAddContact);
            DeleteCommand = new RelayCommand<object>(DeleteContact, CanDeleteContact);
        }

        private void AddContact()
        {
            Contacts.Add(new Contact { Name = Name, Phone = Phone });
            Name = string.Empty;
            Phone = string.Empty;
        }

        private bool CanAddContact() => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Phone);

        private void DeleteContact(object? parameter)
        {
            if (parameter is Contact contact) Contacts.Remove(contact);
        }

        private bool CanDeleteContact(object? parameter) => parameter is Contact;
    }
}