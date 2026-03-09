using System.Windows.Media;

public class GreenTriangleCreator : TriangleCreator
{
    public override Triangle CreateTriangle()
    {
        return new Triangle { Color = Colors.Green };
    }
}