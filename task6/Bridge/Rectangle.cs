namespace StructuralPatternsLab
{
    public class Rectangle : GraphicObject
    {
        private float _x, _y, _width, _height;

        public Rectangle(IRenderingEngine engine, float x, float y, float w, float h) : base(engine)
        {
            _x = x; _y = y; _width = w; _height = h;
        }

        public override void Draw() { _engine.RenderRectangle(_x, _y, _width, _height); }
        public override void Move(float dx, float dy) { _x += dx; _y += dy; }
    }
}