using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabBooking.Models;
using CabBooking.DAL;

namespace CabBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeratorController : Controller
    {

        // Private members
        private readonly ModeratorRepository _repo;
        private readonly CabBookingContext _context;
        private readonly string ViewsRoot = "/Views/Moderator/";
        private readonly string RouteRoot = "/Moderator/";

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
        [HttpGet("ModProfile/{id}")]
        public ActionResult ModProfile(string id)
        {
            var entity = _repo.GetItem(id);

            return entity != null ? View( entity) : NotFound();
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            return View();
        }

        [HttpGet ("CreateAccount")]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpGet ("EditInfo/{id}")]
        public ActionResult EditInfo(string id)
        {
            var entity = _repo.GetModAccount(id); 
            if (entity != null)
            {
                return View(entity);
            }
            return NotFound();
        }

        [HttpPost ("UpdateProfile")]
        public ActionResult UpdateProfile([FromForm] ModeratorModel entity)
        {

            try
            {
                _repo.UpdateMod(entity);
                return Redirect(RouteRoot + "DriverProfile/" + entity?.ID);
            }
            catch
            {
                if (_repo.GetItem(entity?.ID) == null)
                    return NotFound();
                return BadRequest();
            }
        }

        // POST: HomeController/Create
        [HttpPost("Submit")]
        public ActionResult Submit([FromBody] ModeratorModel entity)
        {
            try
            {
                _repo.CreateMod(entity);
                return Ok();
            }
            catch
            {
                return BadRequest();
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
