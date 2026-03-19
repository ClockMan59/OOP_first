using System;

namespace StructuralPatternsLab
{

    public class PrintRenderer : IRenderingEngine
    {
        public void BeginRender() { Console.WriteLine("[Print] Начало рендеринга"); }
        public void EndRender() { Console.WriteLine("[Print] Конец рендеринга"); }
        public void RenderRectangle(float x, float y, float w, float h) { Console.Write($"[Print] Прямоугольник ({x},{y}) размер {w}x{h}"); }
        public void RenderEllipse(float x, float y, float rx, float ry) { Console.Write($"[Print] Эллипс ({x},{y}) радиусы {rx},{ry}"); }
        public void RenderLine(float x1, float y1, float x2, float y2) { Console.Write($"[Print] Линия от ({x1},{y1}) до ({x2},{y2})"); }
    }
}