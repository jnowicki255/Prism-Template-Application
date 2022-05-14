using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PTA.Core;
using PTA.Modules.MainModule.ViewModels;
using PTA.Modules.MainModule.Views;

namespace PTA.Modules.MainModule
{
    public class MainModule : IModule
    {
        private readonly IRegionManager regionManager;

        public MainModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RequestNavigate(RegionNames.MainRegion, ViewsNames.Login);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
            containerRegistry.RegisterForNavigation<VehiclesView, VehiclesViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
        }
    }
}