using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabBooking.Models;
using CabBooking.DAL;

namespace CabBooking.Controllers
{
    public class ModeratorController : Controller
    {

        // Private members
        private readonly UserRepository<ModeratorModel> _repo;
        private readonly CabBookingContext _context;

        //Public Members
        public ModeratorController(CabBookingContext context)
        {
            _context = context;
            _repo = new UserRepository<ModeratorModel>(_context);
        }

        /*CRUD Operations:
         * Create
         * Read
         * Update
         * Delete*/

        // GET: HomeController/Details/5
        public ActionResult GetEntity(string id)
        {
            return View();
        }

        public ActionResult GetAll()
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
        public ActionResult Update([FromBody]ModeratorModel collection)
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
