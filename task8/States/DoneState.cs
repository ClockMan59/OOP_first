using System;
using System.Reflection.Metadata;

namespace PrinterSystemLab
{
    public class DoneState : IDocumentState
    {
        public void AddToQueue(Document document) => Console.WriteLine($"[FSM: Done] '{document.Title}' уже напечатан.");
        public void Print(Document document) => Console.WriteLine($"[FSM: Done] '{document.Title}' уже напечатан.");
        public void CompletePrinting(Document document) { }
        public void FailPrinting(Document document) { }
        public void Reset(Document document) { }
    }
}