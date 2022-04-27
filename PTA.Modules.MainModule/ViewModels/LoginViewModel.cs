using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using PTA.Core.Events;
using PTA.Core.Mvvm;
using PTA.Services.Database.Interfaces.Providers;
using System.Text;
using System.Threading.Tasks;

namespace PTA.Modules.MainModule.ViewModels
{
    public class LoginViewModel : RegionViewModelBase
    {
        #region Private properties
        private readonly IAuthProvider authProvider;
        private readonly IEventAggregator eventAggregator;
        #endregion

        #region Public properties
        public DelegateCommand LoginToApp { get; set; }
        #endregion

        #region Notifable properties
        public string Username { get => Get<string>(); set => Set(value); }
        public string Secret { get => Get<string>(); set => Set(value); }
        public string ErrorMessage { get => Get<string>(); set => Set(value); }
        #endregion

        #region Constructor
        public LoginViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IAuthProvider authProvider)
            : base(regionManager)
        {
            this.authProvider = authProvider;
            this.eventAggregator = eventAggregator;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoginToApp = new DelegateCommand(async () => await LoginToAppExecute(), LoginToAppCanExecute)
                .ObservesProperty(() => Username)
                .ObservesProperty(() => Secret);
        }
        #endregion

        #region Inherited methods
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Username = Secret = ErrorMessage = null;
        }
        #endregion

        #region Commands methods
        private bool LoginToAppCanExecute()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Secret);
        }
        private async Task LoginToAppExecute()
        {
            var authResult = await authProvider.AuthorizeCredentialsAsync(Username, Secret);

            if (authResult.Success)
            {
                this.eventAggregator.GetEvent<UserLoginEvent>().Publish(authResult.Value);
                RegionManager.RequestNavigate(Core.RegionNames.MainRegion, ViewsNames.Dashboard);
            }
            else
            {
                var stringBuilder = new StringBuilder();
                //stringBuilder.Append(authResult.Errors.ErrorMessage);

                foreach (var error in authResult.Errors.Errors)
                {
                    stringBuilder.AppendLine(error.Message);
                }

                ErrorMessage = stringBuilder.ToString();
            }
        }
        #endregion
    }
}
