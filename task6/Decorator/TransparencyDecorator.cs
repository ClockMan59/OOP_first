using System;

namespace StructuralPatternsLab
{

    public class TransparencyDecorator : DrawableDecorator
    {
        private int _opacity;

        public TransparencyDecorator(IDrawable wrappee, int opacity) : base(wrappee)
        {
            _opacity = opacity;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Прозрачность {_opacity}%]");
        }
    }
}