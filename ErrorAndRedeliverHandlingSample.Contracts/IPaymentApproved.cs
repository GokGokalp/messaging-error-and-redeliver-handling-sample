namespace ErrorAndRedeliverHandlingSample.Contracts
{
    public interface IPaymentApproved
    {
        string OrderNumber { get; set; }
    }
}