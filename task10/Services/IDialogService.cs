namespace task10.Services
{
	// Интерфейс для вызова диалоговых окон
	public interface IDialogService
	{
		void ShowInfo(string message);
		void ShowWarning(string message);
		void ShowError(string message);
		bool ShowConfirmation(string message);
	}
}