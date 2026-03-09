using System.Windows.Media;

public class BlueTriangleCreator : TriangleCreator
{
    public override Triangle CreateTriangle()
    {
        return new Triangle { Color = Colors.Blue };
    }
}