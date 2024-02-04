using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using CabBooking.Models;
using CabBooking.DAL;


namespace CabBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class UserController : Controller
    {

        // Private members
        private readonly UserDataRepository _repo;
        private readonly CabBookingContext _context;

        //Public Members
        public UserController(CabBookingContext context)
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
        [HttpGet ("Details/{id}")]
        public ActionResult Details(string id)
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost ("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([FromBody] UserModel entity)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Views/CreateAccount.cshtml", entity);
            }
        }

        // POST: HomeController/Edit/5
        [HttpPost ("Update/{id}")]
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
        [HttpPost ("Delete/{id}")]
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
