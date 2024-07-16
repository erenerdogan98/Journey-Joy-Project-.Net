using FluentValidation;
using JourneyJoy.DTO.ReservationDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationValidator()
        {
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Person count for that reservation is required!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!")
                .MinimumLength(10).WithMessage("Description must at least 10 characters long.")
                .MaximumLength(150).WithMessage("Description must at most 150 characters long.");
            RuleFor(x => x.ReservationDate)
                .NotEmpty().WithMessage("Reservation date is required")
                .Must(date => date >= DateTime.Now).WithMessage("Reservation date cannot be in the past");
        }
    }
}
