using MediatrTutorial.Dto;
using MediatR;

namespace MediatrTutorial.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public CreateCustomerCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }
    }
}