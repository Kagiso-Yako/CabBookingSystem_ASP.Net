using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabBooking.Models;
using CabBooking.DAL;

namespace CabBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeratorController : Controller
    {

        // Private members
        private readonly ModeratorRepository _repo;
        private readonly CabBookingContext _context;

        //Public Members
        public ModeratorController(CabBookingContext context)
        {
            _context = context;
            _repo = new ModeratorRepository(_context);
        }

        /*CRUD Operations:
         * Create
         * Read
         * Update
         * Delete*/

        // GET: HomeController/Details/5
        [HttpGet("GetModProfile/{id}")]
        public ActionResult GetEntity(string id)
        {
            return View("");
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost("CreateModAccount")]
        public ActionResult CreateModerator([FromBody] ModeratorModel entity)
        {
            try
            {
                _repo.CreateMod(entity);
                return Ok();
            }
            catch
            {
                return View();
            }
        }

        // POST: HomeController/Edit/5
        [HttpPost("UpdateModDetails/{id}")]
        public ActionResult Update([FromBody]ModeratorModel moderator)
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
        [HttpPost ("DeleteModAccount/{id}")]
        public ActionResult Delete(string id)
        {
            _repo.Delete(id);
            return View();
        }

        /* Complex operations:
         * Delete other Users
         * Suspend other Users
         * Reset user data
         * See all rides - current: Report user, driver, location and destination. Also search through data.
         * See analytical views: For drivers, passengers, rides, and other analytical data.
         *
         */
    }
}
