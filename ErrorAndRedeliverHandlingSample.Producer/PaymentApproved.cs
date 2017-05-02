using ErrorAndRedeliverHandlingSample.Contracts;

namespace ErrorAndRedeliverHandlingSample.Producer
{
    public class PaymentApproved : IPaymentApproved
    {
        public string OrderNumber { get; set; }
    }
}