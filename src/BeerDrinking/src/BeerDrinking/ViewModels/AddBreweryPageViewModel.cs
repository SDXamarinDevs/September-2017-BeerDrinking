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
using Realms;

namespace BeerDrinking.ViewModels
{
    public class AddBreweryPageViewModel : ViewModelBase
    {
        public AddBreweryPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                   IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
            Title = Resources.AddBreweryPageTitle;
            SaveCommand = new DelegateCommand(OnSaveCommandExecuted);
        }

        public Brewer Model { get; set; }

        public DelegateCommand SaveCommand { get; }

        private void OnSaveCommandExecuted()
        {
            
        }
    }
}