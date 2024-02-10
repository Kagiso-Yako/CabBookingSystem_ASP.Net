using CabBooking.Models;
using CabBooking.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 

namespace CabBooking.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class DriverController : Controller
    {
        // Private members
        private readonly UserDataRepository _repo;
        private readonly CabBookingContext _context;
        private readonly string ViewsRoot = "/Views/Driver/";
        private readonly string RouteRoot = "/Driver/";

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
        public ActionResult DriverProfile(string id)
        {
            var entity = _repo.GetItem(id);

            return entity != null ? View(entity) : NotFound();
        }

        [HttpGet ("CreateAccount")]
        public ActionResult CreateAccount() {

            return View();
        }

        // POST: HomeController/Create
        //[Route  ("")]
        [HttpPost ("Submit")]
        public ActionResult Submit([FromForm] DriverModel entity)
        { 
            try
            {
                _repo.Create(entity);
                return View(ViewsRoot + "WelcomePage.cshtml", entity);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet ("EditProfile/{id}")]
        public ActionResult EditInfo(string id)
        {
            var entity = _repo.GetItem(id);
            if (entity != null)
                try
                {
                    return View(entity);
                }
                catch
                {
                    return Ok();
                }
            else
                return NotFound();

        }

        // POST: HomeController/Edit/5
        [HttpPost ("UpdateProfile")]

        public ActionResult UpdateProfile([FromForm] DriverModel entity)
        {

            try
            {
                _repo.Update(entity);
                return Redirect(RouteRoot + "DriverProfile/" + entity?.ID);
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
