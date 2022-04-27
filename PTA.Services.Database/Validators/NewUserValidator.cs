using FluentValidation;
using PTA.Contracts.Entities.Common.Users;

namespace PTA.Services.Database.Validators
{
    public class NewUserValidator : AbstractValidator<NewUser>
    {
        public NewUserValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Username)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .MaximumLength(200)
                .When(x => x.Email != null);

            RuleFor(x => x.Telephone)
                .MaximumLength(50)
                .When(x => x.Telephone != null);
        }
    }
}
