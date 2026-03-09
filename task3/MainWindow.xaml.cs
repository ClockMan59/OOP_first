using System.Windows;

namespace task3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Это необходимо!
        }
    
        private void colorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            figurePanel.Children.Clear();

            var selected = (colorBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (selected)
            {
                case "Красный":
                    currentFactory = new RedFactory();
                    break;

                case "Синий":
                    currentFactory = new BlueFactory();
                    break;

                case "Зелёный":
                    currentFactory = new GreenFactory();
                    break;

                default:
                    return;
            }

            var circle = currentFactory.CreateCircle();
            var square = currentFactory.CreateSquare();
            var triangle = currentFactory.CreateTriangle();

            figurePanel.Children.Add(circle.CreateUIElement());
            figurePanel.Children.Add(square.CreateUIElement());
            figurePanel.Children.Add(triangle.CreateUIElement());
        }
    }
}

