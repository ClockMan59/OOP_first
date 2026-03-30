using System;

namespace MonitoringSystem.Strategies
{
    public interface IFormatStrategy
    {
        string Format(string message, DateTime timestamp);
    }
}