using System;
using System.IO;
using MonitoringSystem.Strategies;

namespace MonitoringSystem.Handlers
{
    public class FileHandler : EventHandlerBase
    {
        private readonly string _filePath;

        public FileHandler(IFormatStrategy strategy, string filePath) : base(strategy)
        {
            _filePath = filePath;
        }

        protected override void SendMessage(string message)
        {
            File.AppendAllText(_filePath, $"[КАНАЛ: FILE] {message}{Environment.NewLine}");
        }

        protected override void LogResult()
        {
            Console.WriteLine($" --> [System Log]: Уведомление успешно записано в файл {_filePath}.");
        }
    }
}