using System;
using System.Collections.Generic;

namespace StructuralPatternsLab
{
    public class Page
    {
        private List<IDrawable> _drawables = new List<IDrawable>();

        public void Add(IDrawable drawable)
        {
            _drawables.Add(drawable);
        }

        public void Render()
        {
            foreach (var d in _drawables)
            {
                d.Draw();
                Console.WriteLine();
            }
        }
    }
}