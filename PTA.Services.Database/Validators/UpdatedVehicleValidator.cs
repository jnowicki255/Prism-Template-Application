using FluentValidation;
using PTA.Contracts.Entities.Common.Vehicles;

namespace PTA.Services.Database.Validators
{
    public class UpdatedVehicleValidator : AbstractValidator<UpdatedVehicle>
    {
        public UpdatedVehicleValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}
