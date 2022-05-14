using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Contracts.Entities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTA.Services.Database.Interfaces.Providers
{
    public interface IVehicleProvider
    {
        Task<OperationResult<IEnumerable<Vehicle>>> GetVehiclesAsync();

        Task<OperationResult<Vehicle>> GetVehicleAsync(int vehicleId);

        Task<OperationResult<Vehicle>> CreateVehicleAsync(NewVehicle newVehicle);

        Task<BaseOperationResult> UpdateVehicleAsync(UpdatedVehicle updatedVehicle);

        Task<BaseOperationResult> RemoveVehicleAsync(int vehicleId);
    }
}
