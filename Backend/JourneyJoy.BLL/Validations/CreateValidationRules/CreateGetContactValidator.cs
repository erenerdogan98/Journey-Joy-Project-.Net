using FluentValidation;
using JourneyJoy.DTO.GetContactDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateGetContactValidator : AbstractValidator<CreateGetContactDto>
    {
        public CreateGetContactValidator()
        {
            RuleFor(x => x.Mail)
                        .NotEmpty().WithMessage("Email is required!")
                        .EmailAddress().WithMessage("Invalid email format!");

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Please enter your name!")
               .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
               .MaximumLength(30).WithMessage("Name must be at most 30 characters long.")
               .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name must contain only letters");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject can not be null or empty!")
                .MinimumLength(3).WithMessage("Subject must be at last 3 characters long").
                MaximumLength(30).WithMessage("Subject must be at most 30 characters long!");

            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Message body can not be null or empty!")
                .MinimumLength(3).WithMessage("Message Body must be at least 3 characters long.")
                .MaximumLength(150).WithMessage("Message Body must be at most 150 characters long.");

        }
    }
}
