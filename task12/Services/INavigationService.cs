namespace task12.Services
{
	public interface INavigationService
	{
		object? CurrentViewModel { get; }
		void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class;
	}
}