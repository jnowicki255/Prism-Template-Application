using AutoMapper;
using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Contracts.Entities.Result;
using PTA.Repository.Interfaces.Repos;
using PTA.Repository.Interfaces.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTA.Repository.Repos
{
    public partial class Repository : IRepository
    {
        private readonly PTADbContext dbContext;
        private readonly IMapper mapper;
        private readonly ISqlDbSettings sqlDbSettings;

        public Repository(PTADbContext dbContext, IMapper mapper, ISqlDbSettings sqlDbSettings)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.sqlDbSettings = sqlDbSettings;
        }
    }
}