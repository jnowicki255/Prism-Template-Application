using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Repository.Interfaces.Repos
{
    public interface IVehiclesRepository
    {
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleAsync(int vehicleId);
        Task<OperationResult<Vehicle>> CreateVehicleAsync(NewVehicle newVehicle);
        Task<BaseOperationResult> UpdateVehicleAsync(UpdatedVehicle updatedVehicle);
        Task<BaseOperationResult> RemoveVehicleAsync(int vehicleId);

        Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();
        Task<VehicleType> GetVehicleTypeAsync(int vehicleTypeId);
        Task<OperationResult<VehicleType>> CreateVehicleTypeAsync(NewVehicleType newVehicleType);
        Task<BaseOperationResult> UpdateVehicleTypeAsync(VehicleType updatedVehicleType);
        Task<BaseOperationResult> RemoveVehicleTypeAsync(int vehicleTypeId);

        Task<IEnumerable<FuelType>> GetFuelTypesAsync();
        Task<FuelType> GetFuelTypeAsync(int fuelTypeId);
        Task<OperationResult<FuelType>> CreateFuelTypeAsync(NewFuelType newFuelType);
        Task<BaseOperationResult> UpdateFuelTypeAsync(FuelType updatedFuelType);
        Task<BaseOperationResult> RemoveFuelTypeAsync(int fuelTypeId);
    }
}
