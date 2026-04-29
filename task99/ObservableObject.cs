using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace task99
{
    // Базовый класс для уведомления UI об изменениях
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string? prop = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(prop);
            return true;
        }
    }
}