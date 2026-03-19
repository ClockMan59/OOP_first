using System;
using System.Collections.Generic;

namespace StructuralPatternsLab
{
    public class CharacterFactory
    {
        private Dictionary<string, Character> _characters = new Dictionary<string, Character>();

        public Character GetCharacter(char symbol, string font, int fontSize)
        {
            string key = $"{symbol}_{font}_{fontSize}";
            if (!_characters.ContainsKey(key))
            {
                _characters[key] = new Character(symbol, font, fontSize);
                Console.WriteLine($"Creating new character: {key}");
            }
            return _characters[key];
        }

        public int GetCount() => _characters.Count;
    }
}