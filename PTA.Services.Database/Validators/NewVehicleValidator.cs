using FluentValidation;
using PTA.Contracts.Entities.Common.Vehicles;

namespace PTA.Services.Database.Validators
{
    public class NewVehicleValidator : AbstractValidator<NewVehicle>
    {
        public NewVehicleValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Model)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.VinNumber)
                .NotEmpty()
                .MaximumLength(17);

            RuleFor(x => x.LicencePlatesNumber)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.FuelTypeId)
                .GreaterThan(0);

            RuleFor(x => x.VehicleTypeId)
                .GreaterThan(0);
        }
    }
}
