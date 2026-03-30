using System;
using MonitoringSystem.Models;
using MonitoringSystem.Strategies;

namespace MonitoringSystem.Handlers
{
    public abstract class EventHandlerBase
    {
        protected IFormatStrategy _formatStrategy; // текущая стратегия

        protected EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void SetStrategy(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void ProcessEvent(MetricEventArgs e)
        {
            var message = FormatMessage(e.EventType, e.Data); // 1. форматируем по стратегии
            SendMessage(message);                             // 2. отправляем уведомление
            LogResult();                                      // 3. логируем результат
        }

        protected virtual string FormatMessage(string type, object data)
        {
            return _formatStrategy.Format($"[{type}] Data: {data}", DateTime.Now);
        }

        protected abstract void SendMessage(string message);

        protected virtual void LogResult()
        {
            Console.WriteLine(" --> [System Log]: Уведомление успешно обработано базовой системой.");
        }
    }
}