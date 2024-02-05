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
        [HttpGet ("DriverProfile/{id}")]
        public ActionResult GetDriverInfo(string id)
        {
            var entity = _repo.GetItem(id);

            return entity != null ? View("Views/Driver/DriverProfile", entity) : NotFound();
        }

        // POST: HomeController/Create
        [HttpPost ("CreateAccount")]
        public ActionResult CreateDriverAccount([FromBody] DriverModel entity)
        {
            try
            {
                entity.DateAccountCreated = DateTime.Now;
                entity.AccountActive = true;
                entity.Rating = -1;
                _repo.Create(entity);
                return View("Views/Driver/WelcomePage.cshtml", entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: HomeController/Edit/5
        [HttpPost ("UpdateProfile")]
        public ActionResult UpdateProfile([FromBody] DriverModel entity)
        {
            try
            {
                _repo.Update(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                if (_repo.GetItem(entity?.ID) == null)
                    return NotFound();
                return BadRequest();
            }
        }

        // GET: HomeController/Delete/5
        [HttpPost ("DeleteAccount/{id}")]
        public ActionResult Delete(string id)
        {
            var entity = _repo.GetItem(id);
            if (entity != null)
            {
                entity.DateAccountDeactivated = DateTime.Now;
                entity.AccountActive = false;
                _repo.Update(entity);
                return View();
            }
            return BadRequest();
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
