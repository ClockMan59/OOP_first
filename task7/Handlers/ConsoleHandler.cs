using System;
using MonitoringSystem.Strategies;

namespace MonitoringSystem.Handlers
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy) { }

        protected override void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[КАНАЛ: CONSOLE] {message}");
            Console.ResetColor();
        }

        protected override void LogResult()
        {
            Console.WriteLine(" --> [System Log]: Вывод в консоль завершен.");
        }
    }
}