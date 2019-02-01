using MediatR;
using System;

namespace MediatrTutorial.Features.Customer.Events.CustomerCreated
{
    public class CustomerCreatedEvent : INotification
    {
        public CustomerCreatedEvent(string firstName, string lastName, DateTime registrationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            RegistrationDate = registrationDate;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public DateTime RegistrationDate { get; }
    }
}