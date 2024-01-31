using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using CabBooking.Models;


namespace CabBooking.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseModel
    {


        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        [HttpGet ("Details/{id}")]
        public ActionResult GetEntity(string id)
        {
            return View();
        }

        // GET: HomeController/Details/5
        [HttpGet ("Details")]
        public ActionResult GetAllEntities()
        {
            return View();
        }


        // POST: HomeController/Create
        [HttpPost ("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEntity([FromBody]T entity)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            catch
            {
                return View();
            }
        }

        // POST: HomeController/Edit/5
        [HttpPost ("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEntity(int id, [FromBody]T entity)
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

        // POST: HomeController/Delete/5
        [HttpPost ("Delete/{id}")]
        public ActionResult Delete(string id)
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
    }
}
