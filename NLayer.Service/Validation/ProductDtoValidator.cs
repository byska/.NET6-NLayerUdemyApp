using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validation
{
    public class ProductDtoValidator : AbstractValidator<ProductDTO>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");
        }
    }
}
