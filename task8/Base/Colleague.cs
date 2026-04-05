namespace PrinterSystemLab
{
    public abstract class Colleague
    {
        public IMediator Mediator { get; protected set; }

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}