using System.Text.RegularExpressions;

namespace task99.Models
{
    // Модель данных (Model)
    public class Contact : ObservableObject
    {
        private string _name = "";
        private string _phone = "";

        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;

            if (!Validate())
                throw new Exception("Неверные данные контакта");
        }

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

        // Валидация
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;

            return Regex.IsMatch(Phone, @"^(\+7\d{10}|\d{10,11})$");
        }
    }
}