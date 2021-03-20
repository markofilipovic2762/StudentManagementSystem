using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Controllers
{
    public class PredmetController : Controller
    {
        private readonly IPredmetRepository _predmeti;
        private readonly UserManager<ApplicationUser> _userManager;
        public PredmetController(IPredmetRepository predmeti, UserManager<ApplicationUser> userManager)
        {
            _predmeti = predmeti;
            _userManager = userManager;
        }
        // GET: PredmetController
        public IActionResult Index()
        {
            var sviPredmeti = _predmeti.SviPredmeti();
            return View(sviPredmeti);
        }

        // GET: PredmetController/Details/5
        public IActionResult Details(int id)
        {
            var Predmet = _predmeti.GetPredmet(id);
            return View(Predmet);
        }

        // GET: PredmetController/Create
        public async Task<ActionResult> Create()
        {
            var profesors = await _userManager.GetUsersInRoleAsync("Profesor");
            ViewBag.UserId = new SelectList(profesors, "Id","Email");
            return View();
        }

        // POST: PredmetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("UserId,ESPB,Naziv")] Predmet predmet)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var profesors = await _userManager.GetUsersInRoleAsync("Profesor");
            ViewBag.UserId = new SelectList(profesors, "Id", "Email", predmet.UserId);

            _predmeti.SacuvajPredmet(predmet);
            return RedirectToAction("Index");
         
            
        }

        // GET: PredmetController/Edit/5
        public async Task <ActionResult> Edit(int id)
        { 
            var profesors = await _userManager.GetUsersInRoleAsync("Profesor");
            ViewBag.UserId = new SelectList(profesors, "Id", "Email");
            return View(_predmeti.GetPredmet(id));
        }

        // POST: PredmetController/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> EditPredmet(int id)
        {
            var predmet = _predmeti.GetPredmet(id);
            var profesors = await _userManager.GetUsersInRoleAsync("Profesor");
            ViewBag.UserId = new SelectList(profesors, "Id", "Email", predmet.UserId);
            try
            {
                _predmeti.IzmeniPredmet(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PredmetController/Delete/5
        public IActionResult Delete(int id)
        {
            var predmet = _predmeti.GetPredmet(id);
            return View(predmet);
        }

        // POST: PredmetController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _predmeti.IzbrisiPredmet(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
