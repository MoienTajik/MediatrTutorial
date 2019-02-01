using AutoMapper;
using MediatR;
using MediatrTutorial.Data;
using MediatrTutorial.Dto;
using MediatrTutorial.Features.Customer.Events.CustomerCreated;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrTutorial.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        readonly ApplicationDbContext _context;
        readonly IMapper _mapper;
        readonly IMediator _mediator;

        public CreateCustomerCommandHandler(ApplicationDbContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
        {
            Domain.Customer customer = _mapper.Map<Domain.Customer>(createCustomerCommand);

            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // Raising Event ...
            await _mediator.Publish(new CustomerCreatedEvent(customer.FirstName, customer.LastName, customer.RegistrationDate), cancellationToken);

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}