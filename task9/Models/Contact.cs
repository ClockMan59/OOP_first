using task9.ViewModels;

namespace task9.Models
{
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