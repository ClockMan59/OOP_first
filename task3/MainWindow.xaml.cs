using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void colorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            figurePanel.Children.Clear();

            var selected = (colorBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            CircleCreator circleCreator;
            SquareCreator squareCreator;
            TriangleCreator triangleCreator;

            switch (selected)
            {
                case "Красный":
                    circleCreator = new RedCircleCreator();
                    squareCreator = new RedSquareCreator();
                    triangleCreator = new RedTriangleCreator();
                    break;

                case "Синий":
                    circleCreator = new BlueCircleCreator();
                    squareCreator = new BlueSquareCreator();
                    triangleCreator = new BlueTriangleCreator();
                    break;

                case "Зелёный":
                    circleCreator = new GreenCircleCreator();
                    squareCreator = new GreenSquareCreator();
                    triangleCreator = new GreenTriangleCreator();
                    break;

                default:
                    return;
            }

            var circle = circleCreator.CreateCircle();
            var square = squareCreator.CreateSquare();
            var triangle = triangleCreator.CreateTriangle();

            figurePanel.Children.Add(circle.CreateUIElement());
            figurePanel.Children.Add(square.CreateUIElement());
            figurePanel.Children.Add(triangle.CreateUIElement());
        }
    }
}
