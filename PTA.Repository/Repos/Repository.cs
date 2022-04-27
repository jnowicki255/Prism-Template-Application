using AutoMapper;
using PTA.Repository.Interfaces.Repos;
using PTA.Repository.Interfaces.Settings;

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