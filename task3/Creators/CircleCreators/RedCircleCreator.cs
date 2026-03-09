using System.Windows.Media;

public class RedCircleCreator : CircleCreator
{
    public override Circle CreateCircle()
    {
        return new Circle { Color = Colors.Red };
    }
}