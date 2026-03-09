using System.Windows.Media;

public class RedSquareCreator : SquareCreator
{
    public override Square CreateSquare()
    {
        return new Square { Color = Colors.Red };
    }
}