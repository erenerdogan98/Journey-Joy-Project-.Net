using FluentValidation;
using JourneyJoy.DTO.SubAboutDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateSubAboutValidator : AbstractValidator<CreateSubAboutDto>
    {
        public CreateSubAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required!")
                .MinimumLength(3).WithMessage("Title must at least 3 characters long.")
                .MaximumLength(25).WithMessage("Title must at most 25 characters long.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!")
                .MinimumLength(2).WithMessage("Description must at least 2 characters long.")
                .MaximumLength(120).WithMessage("Description must at most 120 characters long.");
        }
    }
}
