using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabBooking.Models;
using CabBooking.DAL;


namespace CabBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengerController : Controller
    {

        // Private members
        private readonly UserDataRepository _repo;
        private readonly CabBookingContext _context;
        private readonly string ViewsRoot = "/Views/Passenger/";
        private readonly string RouteRoot = "/Passenger/";

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
        [HttpGet ("PassengerProfile/{id}")]
        public ActionResult PassengerProfile(string id)
        {
            var entity = _repo.GetItem(id);

            return entity != null ? View(entity) : NotFound();
        }

        [HttpGet ("CreateAccount")]
        public ActionResult CreateAccount() {

            return View();
        }

        // POST: HomeController/Create
        [HttpPost ("Submit")]
        public ActionResult Submit([FromForm] PassengerModel entity)
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


        [HttpGet("EditInfo/{id}")]
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
        public ActionResult UpdateProfile([FromForm] PassengerModel entity)
        {
            try
            {
                _repo.Update(entity);
                return Redirect(RouteRoot + "PassengerProfile/" + entity.ID);
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
