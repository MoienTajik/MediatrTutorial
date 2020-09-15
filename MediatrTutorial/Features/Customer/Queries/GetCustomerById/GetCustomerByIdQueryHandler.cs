using AutoMapper;
using MediatR;
using MediatrTutorial.Data;
using MediatrTutorial.Dto;
using MediatrTutorial.Infrastructure.Exceptions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrTutorial.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Customer customer = await _context.Customers
                .FindAsync(request.CustomerId);

            if (customer == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Customer with given ID is not found.");
            }

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}