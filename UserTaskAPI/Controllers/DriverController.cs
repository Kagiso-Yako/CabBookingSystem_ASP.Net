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
        private readonly UserDataRepository _repo;
        private readonly CabBookingContext _context;

        //Public Members
        public DriverController(CabBookingContext context)
        {
            _context = context;
            _repo = new UserDataRepository(_context);
        }

        /*CRUD Operations:
         * Create
         * Read
         * Update
         * Delete*/

        // GET: HomeController/Details/5
        [HttpGet ("Driver/{id}")]
        public ActionResult GetEntity(string id)
        {
            return View("Views/DriverProfile",_repo.GetItem(id));
        }

        // POST: HomeController/Create
        [HttpPost ("CreateNew")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDriverAccount([FromBody] DriverModel entity)
        {

                _repo.Create(entity);
                return Ok();
        }

        // POST: HomeController/Edit/5
        [HttpPost ("Update")]
        public ActionResult UpdateInformation([FromBody] DriverModel entity)
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
        [HttpPost ("Delete/{id}")]
        public ActionResult Delete(string id)
        {
            return View();
        }

        /* Complex operations
         * Accept ride requests
         * Start ride - Simulating time elapsed and distance travelled
         * End ride - Reporting trip stats, such as cost, receiving payment and tips
         * Rate Experience/User 
         * Chat functionality - Most complex - Unsure how to approach yet. - Not part of core
         * */

    }
}
