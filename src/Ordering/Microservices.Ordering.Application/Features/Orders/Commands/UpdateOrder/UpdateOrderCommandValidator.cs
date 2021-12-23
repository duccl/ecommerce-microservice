﻿using FluentValidation;

namespace Microservices.Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(order => order.Id)
                .NotEmpty().WithMessage("{id} is Required");

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
