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
    public class MainPageViewModel : ViewModelBase
    {
        private IPageDialogService _pageDialogService { get; }
        private ILoggerFacade _logger { get; }
        public MainPageViewModel(INavigationService navigationService, IApplicationStore applicationStore,
                                 IDeviceService deviceService, IPageDialogService pageDialogService, ILoggerFacade logger)
            : base(navigationService, applicationStore, deviceService)
        {
            _pageDialogService = pageDialogService;
            _logger = logger;
            Title = Resources.MainPageTitle;

            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        }

        public string UserName { get; set; }

        public DelegateCommand<string> NavigateCommand { get; }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: put the username here...
            UserName = "User";
        }

        private async void OnNavigateCommandExecuted(string pageName)
        {
            try
            {
                await _navigationService.NavigateAsync($"NavigationPage/{pageName}");
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync(ex.GetType().Name, ex.Message, "Ok");
                _logger.Log(ex);
            }
        }
    }
}