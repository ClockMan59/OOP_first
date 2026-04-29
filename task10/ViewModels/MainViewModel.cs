using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using task10.Models;
using task10.Services;

namespace task10.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        public ObservableCollection<Contact> Contacts { get; } = new();

        private string _name = string.Empty;
        public string Name { get => _name; set => Set(ref _name, value); }

        private string _phone = string.Empty;
        public string Phone { get => _phone; set => Set(ref _phone, value); }

        private Contact? _selectedContact;
        public Contact? SelectedContact { get => _selectedContact; set => Set(ref _selectedContact, value); }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        // Внедрение зависимости через конструктор (Dependency Injection)
        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            AddCommand = new RelayCommand(AddContact, CanAddContact);
            DeleteCommand = new RelayCommand<object>(DeleteContact, CanDeleteContact);
        }

        private void AddContact()
        {
            // Проверка дубликатов с использованием сервиса сообщений
            if (Contacts.Any(c => c.Phone == Phone))
            {
                _dialogService.ShowWarning($"Контакт с номером {Phone} уже существует в книге!");
                return;
            }

            Contacts.Add(new Contact { Name = Name, Phone = Phone });
            _dialogService.ShowInfo($"Контакт {Name} успешно добавлен.");

            Name = string.Empty;
            Phone = string.Empty;
        }

        private bool CanAddContact() => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Phone);

        private void DeleteContact(object? parameter)
        {
            if (parameter is Contact contact)
            {
                // Запрос подтверждения перед удалением
                if (_dialogService.ShowConfirmation($"Вы уверены, что хотите удалить контакт '{contact.Name}'?"))
                {
                    Contacts.Remove(contact);
                }
            }
        }

        private bool CanDeleteContact(object? parameter) => parameter is Contact;
    }
}