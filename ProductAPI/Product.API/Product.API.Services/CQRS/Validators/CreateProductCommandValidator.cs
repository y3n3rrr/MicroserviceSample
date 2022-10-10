using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .MaximumLength(20)
                .MinimumLength(3)
                .WithMessage("Product name must be between 3-20 characters long.");
            RuleFor(p => p.Price)
                .Must(p => p > 0)
                .WithMessage("Enter valid price value");
        }
    }
}