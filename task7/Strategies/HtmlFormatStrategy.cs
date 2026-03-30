using System;

namespace MonitoringSystem.Strategies
{
    public class HtmlFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp)
        {
            return $"<div class='alert'><b>{timestamp:yyyy-MM-dd HH:mm:ss}</b> - {message}</div>";
        }
    }
}