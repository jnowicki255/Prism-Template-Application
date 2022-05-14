using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Interfaces.Repos;
using PTA.Services.Database.Interfaces.Providers;
using PTA.Services.Database.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTA.Services.Database.Providers
{
    public class VehicleProvider : BaseProvider, IVehicleProvider
    {
        public VehicleProvider(IRepository repository, IValidationProvider validationProvider)
            : base(repository, validationProvider)
        { }

        public async Task<OperationResult<IEnumerable<Vehicle>>> GetVehiclesAsync()
        {
            return await repository.GetVehiclesAsync();
        }

        public async Task<OperationResult<Vehicle>> GetVehicleAsync(int vehicleId)
        {
            return await repository.GetVehicleAsync(vehicleId);
        }

        public async Task<OperationResult<Vehicle>> CreateVehicleAsync(NewVehicle newVehicle)
        {
            var validationResult = validationProvider.Validate(newVehicle);

            if (!validationResult.IsValid)
                return new OperationResult<Vehicle>(validationResult.Errors);

            return await repository.CreateVehicleAsync(newVehicle);
        }

        public async Task<BaseOperationResult> UpdateVehicleAsync(UpdatedVehicle updatedVehicle)
        {
            var validationResult = validationProvider.Validate(updatedVehicle);

            if (!validationResult.IsValid)
                return new BaseOperationResult(validationResult.Errors);

            return await repository.UpdateVehicleAsync(updatedVehicle);
        }

        public async Task<BaseOperationResult> RemoveVehicleAsync(int vehicleId)
        {
            return await repository.RemoveVehicleAsync(vehicleId);
        }


    }
}
