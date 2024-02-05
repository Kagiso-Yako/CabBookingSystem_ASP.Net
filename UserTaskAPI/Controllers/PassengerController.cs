using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabBooking.Models;
using CabBooking.DAL;


namespace CabBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : Controller
    {

        // Private members
        private readonly UserDataRepository _repo;
        private readonly CabBookingContext _context;

        //Public Members
        public PassengerController(CabBookingContext context)
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
        [HttpGet ("ProfileInfo/{id}")]
        public ActionResult Details(string id)
        {
            var entity = _repo.GetItem(id);

            return entity != null ? View("Views/Passenger/DriverProfile", entity) : NotFound();
        }

        // POST: HomeController/Create
        [HttpPost ("CreateAccount")]
        public ActionResult CreateUser([FromBody] PassengerModel entity)
        {
            try
            {
                entity.DateAccountCreated = DateTime.Now;
                entity.AccountActive = true;
                entity.Rating = -1;
                _repo.Create(entity);
                return View("Views/Passenger/WelcomePage.cshtml", entity);
            }
            catch
            {
                return View("Views/CreateAccount.cshtml", entity);
            }
        }

        // POST: HomeController/Edit/5
        [HttpPost ("UpdateProfile/{id}")]
        public ActionResult UpdateProfile([FromBody] PassengerModel entity)
        {
            try
            {
                _repo.Update(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                if(_repo.GetItem(entity?.ID) == null)
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
