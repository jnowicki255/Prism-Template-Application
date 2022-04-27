using ModernWpf.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using PTA.Contracts.Entities.Common.Users;
using PTA.Core.Events;
using PTA.Core.Mvvm;
using PTA.Modules.MainModule;

namespace PTA.Startup.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private properties
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        #endregion

        #region Public properties
        public DelegateCommand<NavigationViewItemInvokedEventArgs> NavigateToView { get; set; }
        #endregion

        #region Notifable properties
        public string Header { get => Get<string>(); set => Set(value); }
        public bool IsUserLogged { get => Get<bool>(); set => Set(value); }
        #endregion

        #region Constructor
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

            Initialize();
        }

        private void Initialize()
        {
            Header = "Prism Template Application";
            IsUserLogged = false;

            NavigateToView = new DelegateCommand<NavigationViewItemInvokedEventArgs>(Navigate);

            eventAggregator.GetEvent<UserLoginEvent>().Subscribe(LoginUser);
        }
        #endregion

        #region Support methods
        private void Navigate(NavigationViewItemInvokedEventArgs parameter)
        {
            if (parameter.InvokedItemContainer.Tag.Equals(ViewsNames.Login))
            {
                IsUserLogged = false;
                this.eventAggregator.GetEvent<UserLogoutEvent>().Publish();
            }

            regionManager.RequestNavigate(Core.RegionNames.MainRegion, (string)parameter.InvokedItemContainer.Tag);
        }

        private void LoginUser(User loggedUser)
        {
            IsUserLogged = true;
        }
        #endregion
    }
}