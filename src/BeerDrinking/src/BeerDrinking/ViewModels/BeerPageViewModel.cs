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
    public class BeerPageViewModel : ViewModelBase
    {
        public BeerPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                     IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
            Title = Resources.BeerPageTitle;
        }

        public Beer Model { get; set; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            Model = parameters.GetValue<Beer>("beer");
        }
    }
}