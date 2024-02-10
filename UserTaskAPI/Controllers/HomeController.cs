using Microsoft.AspNetCore.Mvc;
using CabBooking.Models;

namespace CabBooking.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet ("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet ("SignUp")]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet ("About")]
        public ActionResult About()
        {
            return View();
        }
    }
}
