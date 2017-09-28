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

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    // TODO: Handle any tasks that should occur only when navigated back to
                    break;
                case NavigationMode.New:
                    // TODO: Handle any tasks that should occur only when navigated to for the first time
                    break;
            }

            // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
        }

        private void OnSaveCommandExecuted()
        {
            
        }
    }
}