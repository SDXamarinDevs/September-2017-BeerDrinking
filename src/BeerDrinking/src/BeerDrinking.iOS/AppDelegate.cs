using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using FFImageLoading.Forms.Touch;
using FFImageLoading;
using BeerDrinking.Services;

namespace BeerDrinking.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            global::FormsPlugin.Iconize.iOS.IconControls.Init();

            CachedImageRenderer.Init();

            ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new DebugLogger(),
            });

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
            Xamarin.Calabash.Start();
#endif
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
