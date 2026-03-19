namespace StructuralPatternsLab
{
    public class Line : GraphicObject
    {
        private float _x1, _y1, _x2, _y2;

        public Line(IRenderingEngine engine, float x1, float y1, float x2, float y2) : base(engine)
        {
            _x1 = x1; _y1 = y1; _x2 = x2; _y2 = y2;
        }

        public override void Draw() { _engine.RenderLine(_x1, _y1, _x2, _y2); }
        public override void Move(float dx, float dy) { _x1 += dx; _y1 += dy; _x2 += dy; _y2 += dy; }
    }
}