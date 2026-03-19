using System;

namespace StructuralPatternsLab
{
    public class Character
    {

        private char _symbol;
        private string _font;
        private int _fontSize;

        public Character(char symbol, string font, int fontSize)
        {
            _symbol = symbol;
            _font = font;
            _fontSize = fontSize;
        }


        public void Draw(int positionX, int positionY)
        {
            Console.WriteLine($"[Flyweight] Отрисовка '{_symbol}' ({_font}, {_fontSize}pt) на координатах ({positionX}, {positionY})");
        }
    }
}