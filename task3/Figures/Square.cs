using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

public class Square : Figure
{
    public override UIElement CreateUIElement(double size = 60)
    {
        return new Rectangle
        {
            Width = size,
            Height = size,
            Fill = new SolidColorBrush(Color),
            Margin = new Thickness(5)
        };
    }
}