using System;
using System.Threading;

namespace StructuralPatternsLab
{
    public class HighResolutionImage : IImage
    {
        private string _filename;
        private int _width;
        private int _height;

        public HighResolutionImage(string filename)
        {
            _filename = filename;
            Console.Write($"Загрузка {_filename}... ");
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Thread.Sleep(1000);
            _width = 1920;
            _height = 1080;
            Console.WriteLine($"загружено ({_width}x{_height})");
        }

        public void Draw()
        {
            Console.Write($"Отрисовка изображения {_filename}");
        }

        public int GetWidth() => _width;
        public int GetHeight() => _height;
    }
}