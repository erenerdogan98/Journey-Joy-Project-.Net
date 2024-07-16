using FluentValidation;
using JourneyJoy.DTO.CommentDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content field is required!")
                .MinimumLength(2).WithMessage("Content must be at least 2 characters long.")
                .MaximumLength(200).WithMessage("Content must at most 200 characters long.");
        }
    }
}
