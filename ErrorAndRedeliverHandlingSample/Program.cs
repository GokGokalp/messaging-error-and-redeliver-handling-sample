namespace ErrorAndRedeliverHandlingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var paymentApprovedConsumerService = new PaymentApprovedConsumerService();

            paymentApprovedConsumerService.Start();
        }
    }
}