using System.Windows.Media;

public class BlueSquareCreator : SquareCreator
{
    public override Square CreateSquare()
    {
        return new Square { Color = Colors.Blue };
    }
}