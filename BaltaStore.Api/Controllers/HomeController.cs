using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{

    public class HomeController : Controller
    {
        [Route("")]
        public string Version() {
            return "Version 0.0.1";
        }


    }
}
