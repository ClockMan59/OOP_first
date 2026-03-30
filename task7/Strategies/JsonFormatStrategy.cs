using System;

namespace MonitoringSystem.Strategies
{
    public class JsonFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            return $"{{\"timestamp\":\"{timestamp:O}\",\"message\":\"{message}\"}}";
        }
    }
}