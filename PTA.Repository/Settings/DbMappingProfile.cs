using AutoMapper;
using PTA.Contracts.Entities.Common.Users;
using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Repository.Entities;
using System;

namespace PTA.Repository.Settings
{
    public class DbMappingProfile : Profile
    {
        public DbMappingProfile()
        {
            CreateMap<NewUser, DbUser>()
                .AfterMap((src, dest) =>
                {
                    dest.InsertDate = DateTime.UtcNow;
                    dest.ModifyDate = dest.InsertDate;
                });

            CreateMap<UpdatedUser, DbUser>()
                .AfterMap((src, dest) =>
                {
                    dest.ModifyDate = DateTime.UtcNow;
                });

            CreateMap<DbUser, User>();

            CreateMap<NewVehicle, DbVehicle>()
                .AfterMap((src, dest) =>
                {
                    dest.InsertDate = DateTime.UtcNow;
                    dest.ModifyDate = dest.InsertDate;
                });

            CreateMap<UpdatedVehicle, DbVehicle>()
                .AfterMap((src, dest) =>
                {
                    dest.ModifyDate = DateTime.UtcNow;
                });

            CreateMap<DbVehicle, Vehicle>();

            CreateMap<NewFuelType, DbFuelType>();
            CreateMap<DbFuelType, FuelType>();

            CreateMap<NewVehicleType, DbVehicleType>();
            CreateMap<DbVehicleType, VehicleType>();
        }
    }
}
