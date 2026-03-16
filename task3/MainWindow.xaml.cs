using System.Windows;
using System.Windows.Controls;

namespace task3
{
    public partial class MainWindow : Window
    {

        private IFigureFactory _currentFactory;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrawingPanel == null) return;

            DrawingPanel.Children.Clear();

            var selectedItem = (ComboBoxItem)ColorComboBox.SelectedItem;
            if (selectedItem == null) return;

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

            DrawingPanel.Children.Add(_currentFactory.CreateCircle().CreateUIElement());
            DrawingPanel.Children.Add(_currentFactory.CreateSquare().CreateUIElement());
            DrawingPanel.Children.Add(_currentFactory.CreateTriangle().CreateUIElement());
        }
    }
}

