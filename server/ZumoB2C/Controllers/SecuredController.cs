using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace ZumoB2C.Controllers
{
    [MobileAppController]
    public class SecuredController : ApiController
    {
        // GET api/Secured
        [Authorize]
        public string Get()
        {
            return "I come from a secured land!";
        }
    }
}
