using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Contracts.Entities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Repository.Repos
{
    public partial class Repository
    {
        public Task<OperationResult<FuelType>> CreateFuelTypeAsync(NewFuelType newFuelType)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationResult<Vehicle>> CreateVehicleAsync(NewVehicle newVehicle)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationResult<VehicleType>> CreateVehicleTypeAsync(NewVehicleType newVehicleType)
        {
            throw new System.NotImplementedException();
        }

        public Task<FuelType> GetFuelTypeAsync(int fuelTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<FuelType>> GetFuelTypesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Vehicle> GetVehicleAsync(int vehicleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<VehicleType> GetVehicleTypeAsync(int vehicleTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> RemoveFuelTypeAsync(int fuelTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> RemoveVehicleAsync(int vehicleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> RemoveVehicleTypeAsync(int vehicleTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> UpdateFuelTypeAsync(FuelType updatedFuelType)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> UpdateVehicleAsync(UpdatedVehicle updatedVehicle)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> UpdateVehicleTypeAsync(VehicleType updatedVehicleType)
        {
            throw new System.NotImplementedException();
        }
    }
}
