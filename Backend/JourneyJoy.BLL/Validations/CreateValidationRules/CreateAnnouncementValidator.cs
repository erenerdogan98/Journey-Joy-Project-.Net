using FluentValidation;
using JourneyJoy.DTO.AnnouncementDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateAnnouncementValidator : AbstractValidator<CreateAnnouncementDto>
    {
        public CreateAnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required!")
                .MinimumLength(2).WithMessage("Title must at least 2 characters long.")
                .MaximumLength(20).WithMessage("Title must at most 20 characters long.");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required!")
                .MinimumLength(3).WithMessage("Content must at least 3 characters long.")
                .MaximumLength(150).WithMessage("Content must at most 150 characters long.");
        }
    }
}
