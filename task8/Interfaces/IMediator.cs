namespace PrinterSystemLab
{
    public interface IMediator
    {
        void Notify(Colleague sender, string ev, Document document = null);
    }
}