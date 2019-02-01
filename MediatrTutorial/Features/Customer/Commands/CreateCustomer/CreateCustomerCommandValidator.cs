using FluentValidation;

namespace MediatrTutorial.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.LastName).NotEmpty();
        }
    }
}