using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using task11.Services;
using task11.ViewModels;

namespace task11
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            // 1. Сначала регистрируем навигацию
            services.AddSingleton<INavigationService, NavigationService>();

            // 2. Регистрируем все ViewModel экранов
            services.AddTransient<ContactsListViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<ContactEditViewModel>();

            // 3. ОБЯЗАТЕЛЬНО РЕГИСТРИРУЕМ MainWindowViewModel (Эту строчку ты пропустил!)
            services.AddSingleton<MainWindowViewModel>();

            // Экраны (создаются заново при каждом переходе)
            services.AddTransient<ContactsListViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<ContactEditViewModel>();

            // Главное окно
            services.AddSingleton<MainWindow>(sp => {
                var window = new MainWindow();
                // Вот здесь программа падала, потому что не могла найти MainWindowViewModel
                window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
                return window;
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }
}