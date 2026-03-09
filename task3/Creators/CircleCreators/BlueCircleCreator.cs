using System.Windows.Media;

public class BlueCircleCreator : CircleCreator
{
    public override Circle CreateCircle()
    {
        return new Circle { Color = Colors.Blue };
    }
}