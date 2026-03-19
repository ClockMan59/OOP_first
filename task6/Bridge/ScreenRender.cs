using System;

namespace StructuralPatternsLab
{

    public class ScreenRenderer : IRenderingEngine
    {
        public void BeginRender() { Console.WriteLine("[Screen] Начало рендеринга"); }
        public void EndRender() { Console.WriteLine("[Screen] Конец рендеринга"); }
        public void RenderRectangle(float x, float y, float w, float h) { Console.Write($"[Screen] Прямоугольник ({x},{y}) размер {w}x{h}"); }
        public void RenderEllipse(float x, float y, float rx, float ry) { Console.Write($"[Screen] Эллипс ({x},{y}) радиусы {rx},{ry}"); }
        public void RenderLine(float x1, float y1, float x2, float y2) { Console.Write($"[Screen] Линия от ({x1},{y1}) до ({x2},{y2})"); }
    }
}