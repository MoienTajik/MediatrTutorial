using MediatR;
using MediatrTutorial.Dto;
using MediatrTutorial.Features.Customer.Commands.CreateCustomer;
using MediatrTutorial.Features.Customer.Queries.GetCustomerById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace MediatrTutorial.Features.Customer
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns an specific customer.
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Customer Details</returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int customerId)
        {
            CustomerDto customer = await _mediator.Send(new GetCustomerByIdQuery(customerId));
            return Ok(customer);
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Customers
        ///     {
        ///        "FirstName": "Moien",
        ///        "LastName": "Tajik"
        ///     }
        ///
        /// </remarks>
        /// <param name="createCustomerCommand">New customer data include FirstName and LastName.</param>
        /// <returns>New created customer</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            CustomerDto customer = await _mediator.Send(createCustomerCommand);
            return CreatedAtAction(nameof(GetCustomerById), new { customerId = customer.Id }, customer);
        }
    }
}
