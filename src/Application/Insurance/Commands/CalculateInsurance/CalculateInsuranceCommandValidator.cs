using FluentValidation;

namespace Insurance.Application.Insurance.Commands.CalculateInsurance
{
    public class CalculateInsuranceCommandValidator : AbstractValidator<CalculateInsuranceCommand>
    {

        public CalculateInsuranceCommandValidator()
        {
            RuleFor(v => v.ProductIds)
                .NotEmpty().WithMessage("ProductIds is required.");
        }
    }
}
