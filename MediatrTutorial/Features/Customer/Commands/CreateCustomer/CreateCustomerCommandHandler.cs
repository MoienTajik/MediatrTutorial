using AutoMapper;
using MediatR;
using MediatrTutorial.Data;
using MediatrTutorial.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrTutorial.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        readonly ApplicationDbContext _context;
        readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
        {
            Domain.Customer customer = _mapper.Map<Domain.Customer>(createCustomerCommand);

            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}