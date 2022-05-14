using Prism.Commands;
using Prism.Regions;
using PTA.Contracts.Entities.Common.Vehicles;
using PTA.Core.Mvvm;
using PTA.Services.Database.Interfaces.Providers;
using PTA.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PTA.Modules.MainModule.ViewModels
{
    public class VehiclesViewModel : RegionViewModelBase
    {
        #region Private properties
        private readonly IVehicleProvider vehicleProvider;
        #endregion

        #region Public properties
        public DelegateCommand AddVehicle { get; private set; }
        public DelegateCommand<Vehicle> UpdateVehicle { get; private set; }
        public DelegateCommand<Vehicle> DeleteVehicle { get; private set; }
        #endregion

        #region Notifiable properties
        public ObservableList<Vehicle> Vehicles { get => Get<ObservableList<Vehicle>>(); set => Set(value); }
        public Vehicle SelectedVehicle { get => Get<Vehicle>(); set => Set(value); }
        #endregion

        #region Constructor
        public VehiclesViewModel(IRegionManager regionManager, IVehicleProvider vehicleProvider)
            : base(regionManager)
        {
            this.vehicleProvider = vehicleProvider;

            InitialieCommnads();
        }

        private void InitialieCommnads()
        {
            AddVehicle = new DelegateCommand(AddVehicleExecute);
            UpdateVehicle = new DelegateCommand<Vehicle>(UpdateVehicleExecute);
            DeleteVehicle = new DelegateCommand<Vehicle>(DeleteVehicleExecute, DeleteVehicleCanExecute)
                .ObservesProperty(() => SelectedVehicle);
        }
        #endregion

        #region Command methods
        private void AddVehicleExecute()
        {
            var newVehicle = new NewVehicle
            {
                Manufacturer = "Audi",
                Model = "A6",
                FuelTypeId = 1,
                IsRented = false,
                LicencePlatesNumber = "DW111111",
                VinNumber = "AAABBBCCC",
                Mileage = 12000,
                Power = 250,
                VehicleTypeId = 1,
                YearOfProduction = "2018"
            };

            Task.Run(async () =>
            {
                var result = await vehicleProvider.CreateVehicleAsync(newVehicle);
                await LoadVehiclesAsync();
            });
            
        }

        private void UpdateVehicleExecute(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }


        private bool DeleteVehicleCanExecute(Vehicle vehicle)
        {
            return vehicle != null;
        }
        private void DeleteVehicleExecute(Vehicle vehicle)
        {
            Task.Run(async () =>
            {
                var result = await vehicleProvider.RemoveVehicleAsync(vehicle.VehicleId);
                await LoadVehiclesAsync();
            });
        }
        #endregion

        #region Inherited methods
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            Task.Run(async () =>
            {
                await LoadVehiclesAsync();
            });
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
        }
        #endregion

        #region Support methods
        private async Task LoadVehiclesAsync()
        {
            var result = await vehicleProvider.GetVehiclesAsync();
            if (result.Success)
            {
                Vehicles = new ObservableList<Vehicle>(result.Value.ToArray());
                RaisePropertyChanged(nameof(Vehicles));
            }
        }
        #endregion
    }
}
