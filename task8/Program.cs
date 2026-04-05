using System;

namespace PrinterSystemLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            PrintQueue queue = new PrintQueue();
            Logger logger = new Logger();
            Dispatcher dispatcher = new Dispatcher();

            PrintSystemMediator mediator = new PrintSystemMediator(printer, queue, logger);
            dispatcher.SetMediator(mediator);

            Console.WriteLine("--- СЦЕНАРИЙ 1: Успешная печать ---");
            Document doc1 = new Document("Отчет_за_квартал.pdf");
            doc1.SetMediator(mediator);
            doc1.AddToQueue();
            dispatcher.CommandProcessQueue();

            Console.WriteLine("\n--- СЦЕНАРИЙ 2: Ошибка принтера и восстановление ---");
            Document doc2 = new Document("Секретный_чертеж.dwg");
            doc2.SetMediator(mediator);
            doc2.AddToQueue();

            printer.SimulateFailure = true;
            dispatcher.CommandProcessQueue();

            // Попытка закинуть сломанный документ снова в очередь
            doc2.AddToQueue();

            // Сброс и успешная печать
            doc2.Reset();
            doc2.AddToQueue();
            dispatcher.CommandProcessQueue();

            Console.WriteLine("\n--- СЦЕНАРИЙ 3: Проверка финального состояния ---");
            doc1.Print();
            doc1.AddToQueue();

            Console.ReadLine();
        }
    }
}