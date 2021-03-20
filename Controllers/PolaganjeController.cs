using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Controllers
{
    public class PolaganjeController : Controller
    {
        // GET: PolaganjeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PolaganjeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PolaganjeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolaganjeController/Create
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

        // GET: PolaganjeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PolaganjeController/Edit/5
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

        // GET: PolaganjeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PolaganjeController/Delete/5
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
