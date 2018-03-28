using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace ZumoB2CForms
{
    public static class ZumoService
    {
        public static readonly MobileServiceClient CurrentClient = new MobileServiceClient(Constants.ApplicationUrl);

        public async static Task<bool> Login()
        {
            return await App.Authenticator.AuthenticateAsync();
        }

        public async static Task<string> GetUnsecuredData()
        {
            string results = "";
            try
            {
                results = await CurrentClient.InvokeApiAsync<string>("unsecured", HttpMethod.Get, new Dictionary<string, string>());
            }
            catch (Exception ex)
            {
                results = $"ERROR: {ex.Message}";
            }

            return results;
        }

        public async static Task<string> GetSecuredData()
        {
            if (CurrentClient.CurrentUser == null)
                return "Why don't you try logging in first?";

            string results = "";
            try
            {
                // As long as CurrentClient.CurrentUser has a value - the auth token will be sent along in the header - nothing special needs to be done!
                results = await CurrentClient.InvokeApiAsync<string>("secured", HttpMethod.Get, new Dictionary<string, string>()); 
            }
            catch (Exception ex)
            {
                results = $"ERROR: {ex.Message}";
            }

            return results;
        }
    }
}
