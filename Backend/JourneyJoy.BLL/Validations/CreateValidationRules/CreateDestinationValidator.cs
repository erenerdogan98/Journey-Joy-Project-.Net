using FluentValidation;
using JourneyJoy.DTO.DestinationDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateDestinationValidator : AbstractValidator<CreateDestinationDto>
    {
        public CreateDestinationValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters long.")
                .MaximumLength(20).WithMessage("Description must be at most 20 characters long to more explanation you can write in details");
            RuleFor(x => x.Details1).NotEmpty().WithMessage("Details is required!")
                .MinimumLength(3).WithMessage("Details must at least 3 characters long")
                .MaximumLength(250).WithMessage("Details must at most 250 characters long");
            RuleFor(x => x.Day).NotEmpty().WithMessage("Please , write your reservation day ");
            RuleFor(x => x.Night).NotEmpty().WithMessage("Please , write your reservation night");
        }
    }
}
