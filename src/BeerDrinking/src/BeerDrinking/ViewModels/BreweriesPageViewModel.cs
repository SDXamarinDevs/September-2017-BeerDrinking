using Prism.Navigation;
using Prism.Services;
using BeerDrinking.Strings;
using BeerDrinking.Models;
using MvvmHelpers;
using Prism.AppModel;
using Prism.Commands;
using Realms;

namespace BeerDrinking.ViewModels
{
    public class BreweriesPageViewModel : ViewModelBase
    {
        private Realm _realm { get; }
        public BreweriesPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                      IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
            _realm = Realm.GetInstance(Helpers.AppConstants.RealmConfiguration);
            Title = Resources.BreweriesPageTitle;
            Breweries = new ObservableRangeCollection<Brewer>();
            BrewerySelectedCommand = new DelegateCommand<Brewer>(OnBrewerySelectedCommandExecuted);
        }

        public ObservableRangeCollection<Brewer> Breweries { get; set; }

        public DelegateCommand<Brewer> BrewerySelectedCommand { get; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            Breweries.ReplaceRange(_realm.All<Brewer>());
        }

        private async void OnBrewerySelectedCommandExecuted(Brewer brewer)
        {
            // TODO: make a call to the Navigation Service
        }
    }
}