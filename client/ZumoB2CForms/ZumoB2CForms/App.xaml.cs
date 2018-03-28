using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ZumoB2CForms
{
	public partial class App : Application
	{
        public static IAuthenticate Authenticator { get; private set; }
		public App ()
		{
			InitializeComponent();

			MainPage = new ZumoB2CForms.MainPage();
		}

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
