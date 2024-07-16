using FluentValidation;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.AuthDtos;

namespace JourneyJoy.BLL.Validations.CreateValidationRules
{
    public class RegisterAccountValidator : AbstractValidator<RegisterDto>
    {
        private readonly IAuthDAL _authDAL;

        public RegisterAccountValidator(IAuthDAL authDAL)
        {
            _authDAL = authDAL;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please enter your name!")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .MaximumLength(30).WithMessage("Name must be at most 30 characters long.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name must contain only letters"); ;

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Please enter your surname!")
                .MinimumLength(2).WithMessage("Surname must be at least 2 characters long.")
                .MaximumLength(40).WithMessage("Surname must be at most 40 characters long.")
                .Matches(@"^[a-zA-Z]+$").WithMessage("Surname must contain only letters"); ;

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Invalid email format!").Must(IsEmailUnique).WithMessage("This email  has already taken!");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required!")
                .MinimumLength(5).WithMessage("Username must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Username must be at most 20 characters long")
                .Must(IsUserNameUnique).WithMessage("This Username has already taken!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit")
                .Matches(@"[\W]").WithMessage("Password must contain at least one special character (_ * & etc.)");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Confirm password does not match the password");
        }

        private bool IsEmailUnique(string email)
        {
            var response = _authDAL.IsEmailUnique(email);
            return response == true;
        }

        private bool IsUserNameUnique(string username)
        {
            var response = _authDAL.IsEmailUnique(username);
            return response == true;
        }

    }
}
