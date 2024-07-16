using FluentValidation;
using JourneyJoy.DTO.ContactDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Invalid email format!");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Address is required!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required!")
                .Matches(@"^\+?(\d{1,3})?[-. (]?(\d{3})[-. )]?(\d{3})[-. ]?(\d{4})$")
    .WithMessage("Phone number is not in a valid format. Valid formats include: (123) 456-7890, 123-456-7890, 456-7890, or +1-123-456-7890");
        }
    }
}
