using MediatR;
using MediatrTutorial.Dto;

namespace MediatrTutorial.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public GetCustomerByIdQuery(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }
    }
}