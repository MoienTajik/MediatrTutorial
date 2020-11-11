using MediatR;
using MediatrTutorial.Dto;

namespace MediatrTutorial.Features.Customer.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery(int CustomerId) : IRequest<CustomerDto>;
}