namespace StructuralPatternsLab
{
    public class Ellipse : GraphicObject
    {
        private float _x, _y, _rx, _ry;

        public Ellipse(IRenderingEngine engine, float x, float y, float rx, float ry) : base(engine)
        {
            _x = x; _y = y; _rx = rx; _ry = ry;
        }

        public override void Draw() { _engine.RenderEllipse(_x, _y, _rx, _ry); }
        public override void Move(float dx, float dy) { _x += dx; _y += dy; }
    }
}