using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Controllers
{
    public class PolaganjeController : Controller
    {
        private readonly IPolaganjeRepository _polaganja;
        public PolaganjeController(IPolaganjeRepository polaganja)
        {
            _polaganja = polaganja;
        }
        // GET: Sva polaganja
        public ActionResult Index()
        {
            var SvaPolaganja = _polaganja.SvaPolaganja();
            return View(SvaPolaganja);
        }

        // GET: Polaganje/Details/5
        public ActionResult Details(int id)
        {
            var polaganje = _polaganja.GetPolaganje(id);
            return View(polaganje);
        }

        // GET: Polaganje/Create
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
