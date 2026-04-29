using System.Windows;
namespace task99
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new task99.ViewModels.MainViewModel();
        }
    }
}