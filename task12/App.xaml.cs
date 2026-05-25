using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using task12.Models;
using System.Windows;
using task12.Services;
using task12.ViewModels;
using System;

namespace task12
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddDbContext<PhoneBookDbMinaev2307d2Context>(options =>
                options.UseSqlServer("Data Source=BOB;Initial Catalog=PhoneBookDB_Minaev_2307d2;Integrated Security=True;TrustServerCertificate=True"));

            services.AddTransient<ContactsListViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<ContactEditViewModel>();

            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<MainWindow>(sp => {
                var window = new MainWindow();
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