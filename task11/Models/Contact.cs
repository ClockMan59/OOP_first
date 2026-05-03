using task11.ViewModels;

namespace task11.Models
{
    /// <summary>
    /// Модель данных "Контакт".
    /// Наследуется от ObservableObject, чтобы XAML-интерфейс 
    /// мгновенно реагировал на изменение свойств Name и Phone.
    /// </summary>
    public class Contact : ObservableObject
    {
        private string _name = string.Empty;
        private string _phone = string.Empty;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }
    }
}