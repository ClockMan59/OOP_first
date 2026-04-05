using System;
using System.Reflection.Metadata;

namespace PrinterSystemLab
{
    public class PrintingState : IDocumentState
    {
        public void AddToQueue(Document document) => Console.WriteLine($"[FSM: Printing] '{document.Title}' уже печатается, нельзя добавить в очередь.");
        public void Print(Document document) => Console.WriteLine($"[FSM: Printing] '{document.Title}' уже в процессе печати.");

        public void CompletePrinting(Document document)
        {
            document.SetState(new DoneState());
        }

        public void FailPrinting(Document document)
        {
            document.SetState(new ErrorState());
        }

        public void Reset(Document document) { }
    }
}