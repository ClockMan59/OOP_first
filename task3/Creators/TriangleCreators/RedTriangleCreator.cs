using System.Windows.Media;

public class RedTriangleCreator : TriangleCreator
{
    public override Triangle CreateTriangle()
    {
        return new Triangle { Color = Colors.Red };
    }
}