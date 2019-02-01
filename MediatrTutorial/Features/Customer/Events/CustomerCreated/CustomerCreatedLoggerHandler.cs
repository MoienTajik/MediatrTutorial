using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrTutorial.Features.Customer.Events.CustomerCreated
{
    public class CustomerCreatedLoggerHandler : INotificationHandler<CustomerCreatedEvent>
    {
        readonly ILogger<CustomerCreatedLoggerHandler> _logger;

        public CustomerCreatedLoggerHandler(ILogger<CustomerCreatedLoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New customer has been created at {notification.RegistrationDate}: {notification.FirstName} {notification.LastName}");

            return Task.CompletedTask;
        }
    }
}