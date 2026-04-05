namespace PrinterSystemLab
{
    public class Dispatcher : Colleague
    {
        public void CommandProcessQueue()
        {
            Mediator.Notify(this, "ProcessQueue");
        }
    }
}