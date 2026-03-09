using System.Windows.Media;

public class GreenCircleCreator : CircleCreator
{
    public override Circle CreateCircle()
    {
        return new Circle { Color = Colors.Green };
    }
}