using FluentValidation;

namespace Microservices.Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator: AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(order => order.UserName)
                .NotEmpty().WithMessage("{username} is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("{username} max length is 50");

            RuleFor(order => order.Address.EmailAddress)
                .NotEmpty().WithMessage("{EmailAddress} is Required")
                .NotNull();


            RuleFor(order => order.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is Required")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero");
        }
    }
}
