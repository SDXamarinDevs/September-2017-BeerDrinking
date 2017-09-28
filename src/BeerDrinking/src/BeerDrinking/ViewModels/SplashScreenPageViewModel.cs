using System.Threading.Tasks;
using BeerDrinking.Extensions;
using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;
using Realms;

namespace BeerDrinking.ViewModels
{

    public class SplashScreenPageViewModel : ViewModelBase
    {
        public SplashScreenPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                         IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            // TODO: To enable Sync create User Credentials and Login

            var realm = Realm.GetInstance(Helpers.AppConstants.RealmConfiguration);
            realm.Seed();

            // TODO: Make a call to the Navigation Service.
            // NOTE: You will need to Specify the NavigationPage before the landing page...
        }
    }
}