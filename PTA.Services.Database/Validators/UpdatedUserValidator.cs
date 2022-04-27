using FluentValidation;
using PTA.Contracts.Entities.Common.Users;

namespace PTA.Services.Database.Validators
{
    public class UpdatedUserValidator : AbstractValidator<UpdatedUser>
    {
        public UpdatedUserValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0);
        }
    }
}
