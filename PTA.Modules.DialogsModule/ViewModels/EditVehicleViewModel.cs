using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Core.Mvvm;
using PTA.Services.Database.Interfaces.Providers;
using System.Windows;

namespace PTA.Modules.DialogsModule.ViewModels
{
    public class EditVehicleViewModel : RegionViewModelBase, IDialogAware
    {
        #region Private properties
        private readonly IVehicleProvider vehicleProvider;
        #endregion

        #region Public properties
        public event Action<IDialogResult> RequestClose;
        public string Title { get; private set; }
        public DelegateCommand OkCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public DialogType DialogType { get; private set; }
        #endregion

        #region Notifiable properties
        public int VehicleId { get => Get<int>(); set => Set(value); }
        public string Manufacturer { get => Get<string>(); set => Set(value); }
        public string Model { get => Get<string>(); set => Set(value); }
        public string YearOfProduction { get => Get<string>(); set => Set(value); }
        public int Mileage { get => Get<int>(); set => Set(value); }
        public string VinNumber { get => Get<string>(); set => Set(value); }
        public string LicencePlatesNumber { get => Get<string>(); set => Set(value); }
        public bool IsRented { get => Get<bool>(); set => Set(value); }
        public int Power { get => Get<int>(); set => Set(value); }
        public int FuelTypeId { get => Get<int>(); set => Set(value); }
        public int VehicleTypeId { get => Get<int>(); set => Set(value); }
        #endregion

        #region Constructor
        public EditVehicleViewModel(IRegionManager regionManeger, IVehicleProvider vehicleProvider)
            : base(regionManeger)
        {
            this.vehicleProvider = vehicleProvider;

            OkCommand = new DelegateCommand(OkCommandExecute);
            CancelCommand = new DelegateCommand(CancelCommandExecute);
        }
        #endregion

        #region Inherited methods
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.TryGetValue(nameof(Vehicle), out Vehicle vehicle))
            {
                VehicleId = vehicle.VehicleId;
                Manufacturer = vehicle.Manufacturer;
                Model = vehicle.Model;
                YearOfProduction = vehicle.YearOfProduction;
                Mileage = vehicle.Mileage;
                VinNumber = vehicle.VinNumber;
                LicencePlatesNumber = vehicle.LicencePlatesNumber;
                IsRented = vehicle.IsRented;
                Power = vehicle.Power;
                FuelTypeId = vehicle.FuelTypeId;
                VehicleTypeId = vehicle.VehicleTypeId;
            }

            if (parameters.TryGetValue(nameof(DialogType), out DialogType dialogType))
            {
                DialogType = dialogType;
                switch(DialogType)
                {
                    case DialogType.Create:
                        Title = "Add new vehicle";
                        break;

                    case DialogType.Edit:
                        Title = "Edit existing vehicle";
                        break;

                    default:
                        throw new Exception($"{nameof(DialogType)} can be only type of {nameof(DialogType.Create)} or {nameof(DialogType.Edit)}");
                }
            }
        }
        #endregion

        #region Commands methods
        private void OkCommandExecute()
        {
            switch (DialogType)
            {
                case DialogType.Create:
                    Task.Run(async () => await CreateVehicleAsync());
                    break;

                case DialogType.Edit:
                    Task.Run(async () => await EditVehicleAsync());
                    break;
            }
        }

        private void CancelCommandExecute()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.Cancel));
        }
        #endregion

        #region Support methods
        public async Task CreateVehicleAsync()
        {
            var result = await vehicleProvider.CreateVehicleAsync(new NewVehicle
            { 
                Manufacturer = this.Manufacturer,
                Model = this.Model,
                IsRented = this.IsRented,
                LicencePlatesNumber = this.LicencePlatesNumber,
                Mileage = this.Mileage,
                Power = this.Power,
                VinNumber = this.VinNumber,
                YearOfProduction = this.YearOfProduction,
                FuelTypeId = this.FuelTypeId,
                VehicleTypeId = this.VehicleTypeId
            });

            if (result.Success)
                Application.Current.Dispatcher.Invoke(() =>
                    RequestClose.DynamicInvoke(new DialogResult(ButtonResult.OK)));
        }

        public async Task EditVehicleAsync()
        {
            var result = await vehicleProvider.UpdateVehicleAsync(new UpdatedVehicle
            {
                VehicleId = this.VehicleId,
                IsRented = this.IsRented,
                Mileage = this.Mileage
            });


            if (result.Success)
                Application.Current.Dispatcher.Invoke(() =>
                    RequestClose.DynamicInvoke(new DialogResult(ButtonResult.OK)));
        }
        #endregion
    }
}
