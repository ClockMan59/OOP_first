using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using task10.Services;
using task10.ViewModels;

namespace task10
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Настройка IoC-контейнера
            // IDialogService живет всё время работы приложения (Singleton)
            services.AddSingleton<IDialogService, DialogService>();

            // MainViewModel создается каждый раз при запросе (Transient)
            services.AddTransient<MainViewModel>();

            // Регистрация главного окна (Singleton) с передачей DataContext через DI
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Ручной запуск приложения через получение окна из DI контейнера
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}