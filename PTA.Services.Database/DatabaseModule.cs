using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Modularity;
using PTA.Repository.Interfaces.Repos;
using PTA.Repository.Interfaces.Settings;
using PTA.Repository.Settings;
using PTA.Services.Database.Interfaces.Providers;
using PTA.Services.Database.Interfaces.Validation;
using PTA.Services.Database.Providers;
using PTA.Services.Database.Validators;
using PTA.Settings;

namespace PTA.Services.Database
{
    public class DatabaseModule : IModule
    {
        private readonly ISqlDbSettings sqlDbSettings;

        public DatabaseModule(IConfigurationRoot configuration)
        {
            sqlDbSettings = configuration.GetSection(SettingsSections.Sql).Get<SqlDbSettings>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(sqlDbSettings);

            containerRegistry.Register<IRepository, Repository.Repos.Repository>();
            containerRegistry.Register<IAuthRepository, Repository.Repos.Repository>();
            containerRegistry.Register<IUserRepository, Repository.Repos.Repository>();

            containerRegistry.Register<IValidationProvider, ValidationProvider>();
            containerRegistry.Register<IAuthProvider, AuthProvider>();
            containerRegistry.Register<IUserProvider, UserProvider>();
        }
    }
}
