using System.Collections.ObjectModel;
using System.Windows.Input;

namespace task99.ViewModels
{
	// ViewModel (связывает View и Model)
	public class MainViewModel : ObservableObject
	{
		public ObservableCollection<Contact> Contacts { get; } = new();

		private string _name = "";
		public string Name
		{
			get => _name;
			set => Set(ref _name, value);
		}

		private string _phone = "";
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

			DeleteCommand = new RelayCommand(
				DeleteContact,
				() => SelectedContact != null
			);
		}

		private void AddContact()
		{
			try
			{
				var contact = new Contact(Name, Phone);
				Contacts.Add(contact);

				Name = "";
				Phone = "";
			}
			catch
			{
				// можно добавить MessageBox если надо
			}
		}

		private bool CanAddContact()
		{
			return !string.IsNullOrWhiteSpace(Name)
				&& !string.IsNullOrWhiteSpace(Phone);
		}

		private void DeleteContact()
		{
			if (SelectedContact != null)
				Contacts.Remove(SelectedContact);
		}
	}
}