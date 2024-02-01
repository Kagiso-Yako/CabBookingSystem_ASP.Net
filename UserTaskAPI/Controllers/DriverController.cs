using CabBooking.Models;
using CabBooking.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CabBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        // Private members
        private readonly UserRepository<DriverModel> _repo;

        //Public Members
        public DriverController(CabBookingContext context)
        {
            _repo = new UserRepository<DriverModel>(context);
        }

        /*CRUD Operations:
         * Create
         * Read
         * Update
         * Delete*/

        // GET: HomeController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModerator(ModeratorModel collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        public ActionResult Edit([FromBody] ModeratorModel collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            return View();
        }

        /* Complex operations
         * Accept ride requests
         * Start ride - Simulating time elapsed and distance travelled
         * End ride - Reporting trip stats, such as cost, receiving payment and tips
         * Rate Experience/User
         * Chat functionality - Most complex - Unsure how to approach yet.
         * */

    }
}
