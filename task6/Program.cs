using System;
using System.Xml.Linq;

namespace StructuralPatternsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ТЕСТ FLYWEIGHT ===");
            var factory = new CharacterFactory();


            var c1 = factory.GetCharacter('A', "Arial", 12);
            var c2 = factory.GetCharacter('B', "Arial", 12);
            var c3 = factory.GetCharacter('A', "Arial", 12);


            c1.Draw(10, 10);
            c2.Draw(20, 10);
            c3.Draw(30, 10);
            Console.WriteLine($"Всего создано уникальных объектов Flyweight: {factory.GetCount()}");

            Console.WriteLine("\n=== ТЕСТ ДОКУМЕНТА (PROXY, BRIDGE, DECORATOR) ===");

            // 1. Паттерн Bridge (выбираем движок)
            IRenderingEngine screenEngine = new ScreenRenderer();
            Document doc = new Document(screenEngine);

            Page page1 = doc.CreatePage();

            // 2. Паттерн Bridge (создаем фигуры)
            IDrawable rect = new Rectangle(screenEngine, 10, 10, 100, 50);
            IDrawable ellipse = new Ellipse(screenEngine, 50, 50, 30, 20);

            // 3. Паттерн Decorator (оборачиваем фигуры)
            IDrawable decoratedRect = new BorderDecorator(rect, 2);
            IDrawable decoratedEllipse = new TransparencyDecorator(new ShadowDecorator(ellipse), 50);

            // 4. Паттерн Proxy (создаем картинку)
            IDrawable proxyImage = new ImageProxy("huge_cat_picture.png");


            page1.Add(decoratedRect);
            page1.Add(decoratedEllipse);
            page1.Add(proxyImage); 

            Console.WriteLine("\n[Документ сформирован. Начинаем рендеринг...]");

            doc.RenderAll();

            Console.ReadLine();
        }
    }
}