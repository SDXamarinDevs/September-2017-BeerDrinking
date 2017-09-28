using System;
using System.Threading.Tasks;
using BeerDrinking.Services;
using BeerDrinking.Views;
using DryIoc;
using Prism.DryIoc;
using BeerDrinking.Helpers;
using Realms;
using Realms.Sync;
using Prism.Logging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DebugLogger = BeerDrinking.Services.DebugLogger;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BeerDrinking
{
    public partial class App : PrismApplication
    {
        /* 
         * NOTE: 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            SetupLogging();

            await NavigationService.NavigateAsync("SplashScreenPage");
        }

        protected override void RegisterTypes()
        {

            // TODO: Register Realm with a Factory method that will use either the Default or Sync Configuration

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<SplashScreenPage>();
            // Navigating to "TabbedPage?tab=ViewA&tab=ViewB&tab=ViewC will generate a TabbedPage
            // with three tabs for ViewA, ViewB, & ViewC
            Container.RegisterTypeForNavigation<DynamicTabbedPage>("TabbedPage");
            
            // TODO: Register the additional pages you need for the App 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle IApplicationLifecycle
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle IApplicationLifecycle
            base.OnResume();

            // Handle when your app resumes
        }

        protected override ILoggerFacade CreateLogger() =>
            new DebugLogger();

        private void SetupLogging()
        {
            // By default, we set the logger to use the included DebugLogger,
            // which uses System.Diagnostics.Debug.WriteLine to print your message. If you have
            // overridden the default DebugLogger, you will need to update the Logger here to
            // ensure that any calls to your logger in the App.xaml.cs will use your logger rather
            // than the default DebugLogger.
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Logger.Log(e.Exception.ToString(), Category.Exception, Priority.High);
            };
        }
    }
}
