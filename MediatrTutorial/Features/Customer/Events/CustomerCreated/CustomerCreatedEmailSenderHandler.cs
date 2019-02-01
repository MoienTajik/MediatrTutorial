using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrTutorial.Features.Customer.Events.CustomerCreated
{
    public class CustomerCreatedEmailSenderHandler : INotificationHandler<CustomerCreatedEvent>
    {
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // IMessageSender.Send($"Welcome {notification.FirstName} {notification.LastName} !");
            return Task.CompletedTask;
        }
    }
}