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
using Realms;

namespace BeerDrinking.ViewModels
{
    public class AddBeerPageViewModel : ViewModelBase
    {
        public AddBeerPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                     IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
            Title = Resources.AddBeerPageTitle;
        }

        public Beer Model { get; set; }

        public DelegateCommand SaveCommand { get; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Get a list of brewers
        }

        private void OnSaveCommandExecuted()
        {
            
        }
    }
}