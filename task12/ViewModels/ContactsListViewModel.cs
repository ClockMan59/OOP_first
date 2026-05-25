using System.Collections.ObjectModel;
using System.Windows.Input;
using task12.Models;
using task12.Services;

namespace task12.ViewModels
{
	public class ContactsListViewModel : ObservableObject, INavigationAware
	{
        private readonly INavigationService _navigation;
        private readonly PhoneBookDbMinaev2307d2Context _context;

        public ObservableCollection<Contact> Contacts { get; set; }

		private Contact _selectedContact;
		public Contact SelectedContact
		{
			get => _selectedContact;
			set
			{
				_selectedContact = value;
				OnPropertyChanged();
			}
		}

		public ICommand AddCommand { get; }
		public ICommand EditCommand { get; }

        public ContactsListViewModel(INavigationService navigation, PhoneBookDbMinaev2307d2Context context)
        {
            _navigation = navigation;
            _context = context; // Сохраняем его

            // 3. САМАЯ МАГИЯ: вытягиваем контакты из базы данных, 
            // превращаем в список (.ToList) и засовываем в ObservableCollection
            Contacts = new ObservableCollection<Contact>(_context.Contacts.ToList());


            AddCommand = new RelayCommand(() => _navigation.NavigateTo<ContactEditViewModel>(null));


			EditCommand = new RelayCommand(() =>
			{
				if (SelectedContact != null)
				{
					_navigation.NavigateTo<ContactEditViewModel>(SelectedContact);
				}
			});
		}

		public void OnNavigatedTo(object? parameter)
		{
			if (parameter is Contact savedContact)
			{
				if (!Contacts.Contains(savedContact))
				{
					Contacts.Add(savedContact);
				}
			}
		}
	}
}