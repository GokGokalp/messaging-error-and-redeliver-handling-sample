using MassTransit;
using MetroBus;
using System.Configuration;
using System.Threading.Tasks;
using ErrorAndRedeliverHandlingSample.Contracts;

namespace ErrorAndRedeliverHandlingSample.Producer
{
    public class PaymentApprovedProducerService
    {
        private readonly IBusControl _producerBusControl;
        private readonly string _rabbitMqUri;
        private readonly string _rabbitMqUserName;
        private readonly string _rabbitMqPassword;

        public PaymentApprovedProducerService()
        {
            _rabbitMqUri = ConfigurationManager.AppSettings["RabbitMqUri"];
            _rabbitMqUserName = ConfigurationManager.AppSettings["RabbitMqUserName"];
            _rabbitMqPassword = ConfigurationManager.AppSettings["RabbitMqPassword"];

            _producerBusControl = MetroBusInitializer.Instance.UseRabbitMq(_rabbitMqUri, _rabbitMqUserName, _rabbitMqPassword)
                                  .Build();
        }

        public void PublishEvent(IPaymentApproved paymentApproved)
        {
            var task = Task.Run(() => _producerBusControl.Publish(paymentApproved));
            Task.WaitAll(task);
        }
    }
}