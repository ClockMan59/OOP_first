using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

public class Triangle : Figure
{
    public override UIElement CreateUIElement(double size = 60)
    {
        Polygon triangle = new Polygon();

        triangle.Points = new PointCollection
        {
            new Point(size/2,0),
            new Point(0,size),
            new Point(size,size)
        };

        triangle.Fill = new SolidColorBrush(Color);
        triangle.Width = size;
        triangle.Height = size;
        triangle.Margin = new Thickness(5);

        return triangle;
    }
}