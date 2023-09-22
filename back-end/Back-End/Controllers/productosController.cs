using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    public class productosController : Controller
    {
        // GET: productosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: productosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: productosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: productosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: productosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: productosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: productosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
