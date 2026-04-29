using System.Windows;

namespace task10.Services
{
    // Реализация интерфейса через стандартные MessageBox (время жизни - Singleton)
    public class DialogService : IDialogService
    {
        public void ShowInfo(string message) =>
            MessageBox.Show(message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string message) =>
            MessageBox.Show(message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);

        public void ShowError(string message) =>
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

        public bool ShowConfirmation(string message)
        {
            var result = MessageBox.Show(message, "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}