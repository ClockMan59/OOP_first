using System.Windows;
using System.Windows.Controls;

namespace task3
{
    public partial class MainWindow : Window
    {
        // Клиентский код работает ТОЛЬКО с абстракцией фабрики
        private IFigureFactory _currentFactory;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrawingPanel == null) return;

            DrawingPanel.Children.Clear(); // Очищаем панель от старых фигур

            var selectedItem = (ComboBoxItem)ColorComboBox.SelectedItem;
            if (selectedItem == null) return;

            // 1. Выбираем нужную фабрику в зависимости от цвета
            switch (selectedItem.Content.ToString())
            {
                case "Красный":
                    _currentFactory = new RedFactory();
                    break;
                case "Синий":
                    _currentFactory = new BlueFactory();
                    break;
                case "Зелёный":
                    _currentFactory = new GreenFactory();
                    break;
                default:
                    return;
            }

            // 2. Создаем фигуры через интерфейс фабрики и выводим на экран
            // Обрати внимание: теперь мы вызываем методы у _currentFactory, 
            // не задумываясь о том, объекты какого именно цвета она производит.
            DrawingPanel.Children.Add(_currentFactory.CreateCircle().CreateUIElement());
            DrawingPanel.Children.Add(_currentFactory.CreateSquare().CreateUIElement());
            DrawingPanel.Children.Add(_currentFactory.CreateTriangle().CreateUIElement());
        }
    }
}

