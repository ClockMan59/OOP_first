using System.Windows.Media;

public class RedFactory : IFigureFactory
{
    public Circle CreateCircle()
    {
        return new Circle { Color = Colors.Red };
    }

    public Square CreateSquare()
    {
        return new Square { Color = Colors.Red };
    }

    public Triangle CreateTriangle()
    {
        return new Triangle { Color = Colors.Red };
    }
}