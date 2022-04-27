using FluentValidation;
using PTA.Repository.Requests;

namespace PTA.Services.Database.Validators
{
    public class SearchUsersRequestValidator : AbstractValidator<SearchUserRequest>
    {
        public SearchUsersRequestValidator()
        {

        }
    }
}
