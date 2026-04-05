using System;

namespace PrinterSystemLab
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}