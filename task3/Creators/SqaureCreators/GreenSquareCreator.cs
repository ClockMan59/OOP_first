using System.Windows.Media;

public class GreenSquareCreator : SquareCreator
{
    public override Square CreateSquare()
    {
        return new Square { Color = Colors.Green };
    }
}