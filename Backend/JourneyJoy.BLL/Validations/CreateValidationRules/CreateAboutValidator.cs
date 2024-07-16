using FluentValidation;
using JourneyJoy.DTO.AboutDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required!")
                .MinimumLength(2).WithMessage("Title must at least 2 characters long")
                .MaximumLength(20).WithMessage("Title must at most 20 characters long");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Second title field is required!")
                .MinimumLength(2).WithMessage("Must at least 2 characters long")
                .MaximumLength(40).WithMessage("Must at most 40 characters long");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
                .MinimumLength(5).WithMessage("Description must at least 5 characters long")
                .MaximumLength(300).WithMessage("Description must at most 300 characters long");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Image is required!");
        }
    }
}
