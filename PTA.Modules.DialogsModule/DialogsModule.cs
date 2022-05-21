using Prism.Ioc;
using Prism.Modularity;
using PTA.Modules.DialogsModule.ViewModels;
using PTA.Modules.DialogsModule.Views;

namespace PTA.Modules.DialogsModule
{
    public class DialogsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<EditVehicleDialog, EditVehicleViewModel>(DialogsNames.EditVehicle);
        }
    }
}
