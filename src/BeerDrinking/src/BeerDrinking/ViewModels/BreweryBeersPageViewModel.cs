using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Navigation;
using Prism.Services;
using BeerDrinking.Strings;
using BeerDrinking.Models;
using Prism.AppModel;
using MvvmHelpers;

namespace BeerDrinking.ViewModels
{
    public class BreweryBeersPageViewModel : ViewModelBase
    {
        public BreweryBeersPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                     IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
            Title = Resources.BreweryBeersPageTitle;
            Beers = new ObservableRangeCollection<Beer>();
            BeerSelectedCommand = new DelegateCommand<Beer>(OnBeerSelectedCommandExecuted);
        }

        public ObservableRangeCollection<Beer> Beers { get; set; }

        public DelegateCommand<Beer> BeerSelectedCommand { get; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Get the Brewer from the Navigation Parameters and Add/Replace the Beers from the Brewer's Beers
        }

        private async void OnBeerSelectedCommandExecuted(Beer beer)
        {
            // TODO: make a call to the Navigation Service
        }
    }
}