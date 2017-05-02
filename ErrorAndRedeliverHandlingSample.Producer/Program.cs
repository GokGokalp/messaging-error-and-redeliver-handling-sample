namespace ErrorAndRedeliverHandlingSample.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var paymentApprovedProducerService = new PaymentApprovedProducerService();

            for (int i = 0; i < 1; i++)
            {
                paymentApprovedProducerService.PublishEvent(new PaymentApproved()
                {
                    OrderNumber = i.ToString()
                });
            }
        }
    }
}