using System;
using MonitoringSystem.Models;

namespace MonitoringSystem.Monitor
{
    public class EventMonitor
    {
        public event MetricEventHandler? OnMetricExceeded;

        public void CheckMetric(string metricName, double value, double threshold)
        {
            Console.WriteLine($"\n[Monitor]: Checking {metricName} ({value} vs threshold {threshold})");

            if (value > threshold)
            {
                var eventData = new MetricData(metricName, value, threshold, DateTime.Now);

                OnMetricExceeded?.Invoke(new MetricEventArgs(eventType: metricName + "_Exceeded", data: eventData));
            }
        }
    }
}