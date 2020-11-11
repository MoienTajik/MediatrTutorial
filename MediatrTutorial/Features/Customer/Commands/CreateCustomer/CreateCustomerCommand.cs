using MediatrTutorial.Dto;
using MediatR;

namespace MediatrTutorial.Features.Customer.Commands.CreateCustomer
{
    public record CreateCustomerCommand(string FirstName, string LastName) : IRequest<CustomerDto>;
}