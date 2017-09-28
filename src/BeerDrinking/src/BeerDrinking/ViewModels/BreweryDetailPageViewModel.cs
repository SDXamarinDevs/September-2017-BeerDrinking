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

namespace BeerDrinking.ViewModels
{
    public class BreweryDetailPageViewModel : ViewModelBase
    {
        public BreweryDetailPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                     IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
            Title = Resources.BreweryDetailPageTitle;
        }

        public Brewer Model { get; set; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Set the Model from the Brewer passed in the Navigation Parameters
        }
    }
}