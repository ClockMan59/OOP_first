using System;

namespace StructuralPatternsLab
{

    public class ShadowDecorator : DrawableDecorator
    {
        public ShadowDecorator(IDrawable wrappee) : base(wrappee) { }

        public override void Draw()
        {
            base.Draw();
            Console.Write(" [С тенью]");
        }
    }
}