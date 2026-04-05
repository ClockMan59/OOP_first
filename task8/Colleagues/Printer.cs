using System;

namespace PrinterSystemLab
{
    public class Printer : Colleague
    {
        public bool SimulateFailure { get; set; } = false;

        public void StartPrint(Document document)
        {
            Console.WriteLine($"[Принтер] Физическая печать '{document.Title}'...");

            if (SimulateFailure)
            {
                SimulateFailure = false;
                Mediator.Notify(this, "PrintFailed", document);
            }
            else
            {
                Mediator.Notify(this, "PrintSuccess", document);
            }
        }
    }
}