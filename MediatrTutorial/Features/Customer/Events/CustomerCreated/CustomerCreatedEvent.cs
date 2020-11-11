using MediatR;
using System;

namespace MediatrTutorial.Features.Customer.Events.CustomerCreated
{
    public record CustomerCreatedEvent(string FirstName, 
        string LastName,
        DateTime RegistrationDate) : INotification;
}