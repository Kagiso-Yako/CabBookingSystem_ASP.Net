using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using CabBooking.Models;
using CabBooking.DAL;


namespace CabBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class PassengerController : Controller
    {

        // Private members
        private readonly UserDataRepository<PassengerModel> _repo;
        private readonly CabBookingContext _context;

        //Public Members
        public PassengerController(CabBookingContext context)
        {
            _context = context;
            _repo = new UserDataRepository<PassengerModel>(_context);
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

        /* Complex operations:
         * Order ride
         * See available drivers and select
         * Pay/Tip
         * Emergency Page :- in case something goes wrong or user feels unsafe.
         * Chat feature - difficult task.
         * 
         */

    }
}
