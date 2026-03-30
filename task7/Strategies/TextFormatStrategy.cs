using System;

namespace MonitoringSystem.Strategies
{
    public class TextFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            return $"[{timestamp:yyyy-MM-dd HH:mm:ss}] {message}";
        }
    }
}