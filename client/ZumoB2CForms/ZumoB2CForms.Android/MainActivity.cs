using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.MobileServices;
using Android.Content;

namespace ZumoB2CForms.Droid
{
    [Activity(Label = "ZumoB2CForms",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        MobileServiceUser user;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            App.Init((IAuthenticate)this);
            LoadApplication(new App());
        }
        public async Task<bool> AuthenticateAsync()
        {
            bool success = false;

            try
            {
                if (user == null)
                {
                    await ZumoService.CurrentClient.LoginAsync(this, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, Constants.UrlScheme);
                }
                success = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"*** ERROR: {ex.Message}");
            }

            return success;
        }
    }
}

