using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Microsoft.WindowsAzure.MobileServices;

namespace ZumoB2CForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected async void Login(object sender, EventArgs e)
        {
            await ZumoService.Login();
        }

        protected async void GetUnsecured(object sender, EventArgs e)
        {
            var results = await ZumoService.GetUnsecuredData();

            await DisplayAlert("The Results", $"Unsecured Results: {results}", "OK");
        }

        protected async void GetSecured(object sender, EventArgs e)
        {
            var results = await ZumoService.GetSecuredData();

            await DisplayAlert("The Results", $"Secured Results: {results}", "OK");
        }
	}
}
