using ErrorAndRedeliverHandlingSample.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace ErrorAndRedeliverHandlingSample
{
    public class PaymentApprovedConsumer : IConsumer<IPaymentApproved>
    {
        public async Task Consume(ConsumeContext<IPaymentApproved> context)
        {
            int? maxAttempts = context.Headers.Get<int>("MT-Redelivery-Count", default(int?));

            if (maxAttempts > 3)
            {
                throw new Exception("Something's happened during processing...");
            }

            Console.WriteLine($"Attempts: {maxAttempts} Order number: {context.Message.OrderNumber}");

            await context.Defer(TimeSpan.FromMinutes(1));
        }
    }
}