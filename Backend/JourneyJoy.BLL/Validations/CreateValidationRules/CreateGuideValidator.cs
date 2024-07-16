using FluentValidation;
using JourneyJoy.DTO.GuideDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateGuideValidator : AbstractValidator<CreateGuideDto>
    {
        public CreateGuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Guide full name is required! ")
                .MinimumLength(2).WithMessage("Full Name must be at least 2 characters long.")
               .MaximumLength(50).WithMessage("Full Name must be at most 50 characters long.")
               .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name must contain only letters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!")
                .MinimumLength(3).WithMessage("Description must at least 3 characters long")
                .MaximumLength(200).WithMessage("Description must at most 200 characters long");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Please , entry guide image Url");
        }
    }
}
