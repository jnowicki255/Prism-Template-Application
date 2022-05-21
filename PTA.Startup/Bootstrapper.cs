using AutoMapper;
using Microsoft.Extensions.Configuration;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using PTA.Modules.DialogsModule;
using PTA.Modules.MainModule;
using PTA.Repository.Settings;
using PTA.Services.Database;
using PTA.Startup.Views;
using System.Windows;

namespace PTA.Startup
{
    public class Bootstrapper : PrismBootstrapper
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Bootstrapper()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"globalSettings.json", optional: false)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(Configuration);
            containerRegistry.RegisterInstance(CreateMapper());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<DatabaseModule>();
            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<DialogsModule>();
        }

        private IMapper CreateMapper()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DbMappingProfile());
            }).CreateMapper();
        }
    }
}
