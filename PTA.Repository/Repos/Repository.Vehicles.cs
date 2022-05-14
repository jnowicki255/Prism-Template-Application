using Microsoft.EntityFrameworkCore;
using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Repository.Repos
{
    public partial class Repository
    {
        #region Vehicles
        public async Task<OperationResult<Vehicle>> CreateVehicleAsync(NewVehicle newVehicle)
        {
            var dbVehicle = mapper.Map<DbVehicle>(newVehicle);
            await dbContext.Vehicles.AddAsync(dbVehicle);
            await dbContext.SaveChangesAsync();

            var savedVehicle = mapper.Map<Vehicle>(dbVehicle);
            return new OperationResult<Vehicle>(savedVehicle);
        }

        public async Task<OperationResult<Vehicle>> GetVehicleAsync(int vehicleId)
        {
            var dbVehicle = await dbContext.Vehicles.SingleOrDefaultAsync(x => x.VehicleId == vehicleId);
            return new OperationResult<Vehicle>(mapper.Map<Vehicle>(dbVehicle));
        }

        public async Task<OperationResult<IEnumerable<Vehicle>>> GetVehiclesAsync()
        {
            var dbVehicles = await dbContext.Vehicles.ToArrayAsync();
            return new OperationResult<IEnumerable<Vehicle>>(mapper.Map<Vehicle[]>(dbVehicles));
        }

        public async Task<BaseOperationResult> RemoveVehicleAsync(int vehicleId)
        {
            var dbVehicle = await dbContext.Vehicles.SingleOrDefaultAsync(x => x.VehicleId == vehicleId);

            if (dbVehicle == null)
                return new BaseOperationResult($"Vehicle with id [{vehicleId}] was not found.");

            dbContext.Vehicles.Remove(dbVehicle);
            await dbContext.SaveChangesAsync();

            return BaseOperationResult.SuccessfulOperation;
        }

        public async Task<BaseOperationResult> UpdateVehicleAsync(UpdatedVehicle updatedVehicle)
        {
            var dbVehicle = await dbContext.Vehicles.SingleOrDefaultAsync(x => x.VehicleId == updatedVehicle.VehicleId);

            if (dbVehicle == null)
                return new BaseOperationResult($"Vehicle with id [{updatedVehicle.VehicleId}] was not found.");

            dbContext.Entry(dbVehicle).CurrentValues.SetValues(updatedVehicle);
            dbVehicle.ModifyDate = DateTime.UtcNow;
            await dbContext.SaveChangesAsync();

            return BaseOperationResult.SuccessfulOperation;
        }
        #endregion

        #region VehicleTypes
        public Task<OperationResult<VehicleType>> CreateVehicleTypeAsync(NewVehicleType newVehicleType)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationResult<VehicleType>> GetVehicleTypeAsync(int vehicleTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<VehicleType>>> GetVehicleTypesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> RemoveVehicleTypeAsync(int vehicleTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> UpdateVehicleTypeAsync(VehicleType updatedVehicleType)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region FuelTypes
        public Task<OperationResult<FuelType>> CreateFuelTypeAsync(NewFuelType newFuelType)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationResult<FuelType>> GetFuelTypeAsync(int fuelTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<FuelType>>> GetFuelTypesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> RemoveFuelTypeAsync(int fuelTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BaseOperationResult> UpdateFuelTypeAsync(FuelType updatedFuelType)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
