using MassTransit;
using MetroBus;
using System.Configuration;

namespace ErrorAndRedeliverHandlingSample
{
    public class PaymentApprovedConsumerService
    {
        private readonly IBusControl _consumerBusControl;
        private readonly string _rabbitMqUri;
        private readonly string _rabbitMqUserName;
        private readonly string _rabbitMqPassword;
        private readonly string _queueName;

        public PaymentApprovedConsumerService()
        {
            _rabbitMqUri = ConfigurationManager.AppSettings["RabbitMqUri"];
            _rabbitMqUserName = ConfigurationManager.AppSettings["RabbitMqUserName"];
            _rabbitMqPassword = ConfigurationManager.AppSettings["RabbitMqPassword"];
            _queueName = ConfigurationManager.AppSettings["FooQueue"];

            _consumerBusControl =
                MetroBusInitializer.Instance.UseRabbitMq(_rabbitMqUri, _rabbitMqUserName, _rabbitMqPassword)
                //.UseIncrementalRetryPolicy(retryLimit: 5, initialIntervalFromMinute: 10, intervalIncrementFromMinute: 10)
                //.UseCircuitBreaker(tripThreshold: 15, activeThreshold: 10, resetInterval: 5)
                //.UseRateLimiter(rateLimit: 5, interval: 1000)
                .UseDelayedExchangeMessageScheduler()
                .InitializeConsumer<PaymentApprovedConsumer>(_queueName).Build();
        }

        public void Start()
        {
            _consumerBusControl.Start();
        }

        public void Stop()
        {
            _consumerBusControl.Stop();
        }
    }
}