using System;
using MonitoringSystem.Models;
using MonitoringSystem.Monitor;
using MonitoringSystem.Strategies;
using MonitoringSystem.Handlers;

namespace MonitoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЗАПУСК СИСТЕМЫ МОНИТОРИНГА ===\n");

            // 1. Создаем монитор (издателя)
            var monitor = new EventMonitor();

            // 2. Создаем подписчиков с начальными стратегиями
            var consoleHandler = new ConsoleHandler(new TextFormatStrategy());
            var fileHandler = new FileHandler(new JsonFormatStrategy(), "alerts.log");

            // 3. Подписываем их на событие монитора (паттерн Наблюдатель)
            monitor.OnMetricExceeded += consoleHandler.ProcessEvent;
            monitor.OnMetricExceeded += fileHandler.ProcessEvent;

            // 4. Моделируем события
            monitor.CheckMetric("CPU", 45.0, 80.0); // Норма, ничего не произойдет
            monitor.CheckMetric("CPU", 95.5, 80.0); // Превышение, сработают оба подписчика

            monitor.CheckMetric("Memory_GB", 14.2, 16.0); // Норма
            monitor.CheckMetric("Network_Traffic_MB", 2500, 1000); // Превышение

            // 5. Демонстрация смены стратегии на лету (паттерн Стратегия)
            Console.WriteLine("\n=== МЕНЯЕМ СТРАТЕГИЮ КОНСОЛИ НА HTML ===\n");
            consoleHandler.SetStrategy(new HtmlFormatStrategy());

            // 6. Генерируем еще одно событие
            monitor.CheckMetric("Memory_GB", 15.8, 15.0); // Превышение, консоль выведет HTML

            Console.WriteLine("\nРабота завершена. Нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}