using FluentValidation;
using JourneyJoy.DTO.FeatureDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateFeatureValidator : AbstractValidator<CreateFeatureDto>
    {
        public CreateFeatureValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required!")
                .MinimumLength(2).WithMessage("Title must at least 2 characters long.")
                .MaximumLength(20).WithMessage("Title must at most 20 characters long.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
                .MinimumLength(5).WithMessage("Description must at least 5 characters long.")
                .MaximumLength(150).WithMessage("Description must at most 150 characters long.");
        }
    }
}
