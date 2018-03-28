using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;

namespace ZumoB2CForms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IAuthenticate
    {

        MobileServiceUser user;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            global::Xamarin.Forms.Forms.Init();

            App.Init(this);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public async Task<bool> AuthenticateAsync()
        {
            bool success = false;

            try
            {
                if (user == null)
                {
                    user = await ZumoService.CurrentClient.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,
                                                                      MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory,
                                                                      Constants.UrlScheme);
                }

                success = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"*** ERROR: {ex.Message}");
            }

            return success;
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return ZumoService.CurrentClient.ResumeWithURL(url);
        }
    }
}
