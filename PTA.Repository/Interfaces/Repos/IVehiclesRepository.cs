using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Contracts.Entities.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTA.Repository.Interfaces.Repos
{
    public interface IVehiclesRepository
    {
        Task<OperationResult<IEnumerable<Vehicle>>> GetVehiclesAsync();
        Task<OperationResult<Vehicle>> GetVehicleAsync(int vehicleId);
        Task<OperationResult<Vehicle>> CreateVehicleAsync(NewVehicle newVehicle);
        Task<BaseOperationResult> UpdateVehicleAsync(UpdatedVehicle updatedVehicle);
        Task<BaseOperationResult> RemoveVehicleAsync(int vehicleId);

        Task<OperationResult<IEnumerable<VehicleType>>> GetVehicleTypesAsync();
        Task<OperationResult<VehicleType>> GetVehicleTypeAsync(int vehicleTypeId);
        Task<OperationResult<VehicleType>> CreateVehicleTypeAsync(NewVehicleType newVehicleType);
        Task<BaseOperationResult> UpdateVehicleTypeAsync(VehicleType updatedVehicleType);
        Task<BaseOperationResult> RemoveVehicleTypeAsync(int vehicleTypeId);

        Task<OperationResult<IEnumerable<FuelType>>> GetFuelTypesAsync();
        Task<OperationResult<FuelType>> GetFuelTypeAsync(int fuelTypeId);
        Task<OperationResult<FuelType>> CreateFuelTypeAsync(NewFuelType newFuelType);
        Task<BaseOperationResult> UpdateFuelTypeAsync(FuelType updatedFuelType);
        Task<BaseOperationResult> RemoveFuelTypeAsync(int fuelTypeId);
    }
}
