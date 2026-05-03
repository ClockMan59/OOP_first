using System.Collections.ObjectModel;
using System.Windows.Input;
using task11.Models;
using task11.Services;

namespace task11.ViewModels
{
	public class ContactsListViewModel : ObservableObject, INavigationAware
	{
		private readonly INavigationService _navigation;

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

		public ContactsListViewModel(INavigationService navigation)
		{
			_navigation = navigation;

			Contacts = new ObservableCollection<Contact>();


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