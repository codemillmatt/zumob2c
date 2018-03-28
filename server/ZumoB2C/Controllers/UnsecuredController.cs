using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace ZumoB2C.Controllers
{
    [MobileAppController]
    public class UnsecuredController : ApiController
    {
        // GET api/Unsecured
        public string Get()
        {
            return "😱";
        }
    }
}
