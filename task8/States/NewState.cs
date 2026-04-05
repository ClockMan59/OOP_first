using System.Reflection.Metadata;

namespace PrinterSystemLab
{
    public class NewState : IDocumentState
    {
        public void AddToQueue(Document document)
        {
            document.Mediator?.Notify(document, "AddToQueue", document);
        }

        public void Print(Document document)
        {
            document.Mediator?.Notify(document, "RequestPrint", document);
        }

        public void CompletePrinting(Document document) { }
        public void FailPrinting(Document document) { }
        public void Reset(Document document) { }
    }
}