using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentMS.Controllers
{
    public class PolaganjeController : Controller
    {
        private readonly IPolaganjeRepository _polaganja;
        private readonly IIspitRepository _ispiti;
        private readonly UserManager<ApplicationUser> _userManager;
        public PolaganjeController(IPolaganjeRepository polaganja, IIspitRepository ispiti, UserManager<ApplicationUser> userManager)
        {
            _polaganja = polaganja;
            _userManager = userManager;
            _ispiti = ispiti;
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
        public async Task<ActionResult> Create()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            ViewBag.UserId = new SelectList(students, "Id", "Email");

            var ispiti = _ispiti.SviIspiti();
            ViewBag.IspitId = new SelectList(ispiti, "Id", "Predmet.Naziv", "DatumIspita");

            return View();
        }

        // POST: PolaganjeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id, Ocena, OsvojenoBodova, RedniBrojPolaganja, UserId, IspitId")] Polaganje polaganje)
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            ViewBag.UserId = new SelectList(students, "Id", "Email", polaganje.UserId);

            var ispiti = _ispiti.SviIspiti();
            ViewBag.IspitId = new SelectList(ispiti, "Id", "Predmet.Naziv", polaganje.IspitId);
            polaganje.RedniBrojPolaganja += 1;
            try
            {
                _polaganja.SacuvajPolaganje(polaganje);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(polaganje);
            }
        }

        [HttpPost]
        public void PrijaviIspit(int id)
        {
            _polaganja.PrijaviIspit(id);
            RedirectToAction("Index", "Polaganje");
        }

        public ActionResult IspitiStudenta(string id)
        {
            var ispiti = _polaganja.IspitiStudenta(id);

            return View(ispiti);
        }

        public ActionResult MojiIspiti()
        {
            var mojiispiti = _polaganja.MojaPolaganja();
            return View(mojiispiti);
        }

        public ActionResult PolaganjaKodProfesora()
        {
            var polaganja = _polaganja.PolaganjaKodProfesora();
            return View(polaganja);
        }

        // GET: PolaganjeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            ViewBag.UserId = new SelectList(students, "Id", "Email");

            var ispiti = _ispiti.SviIspiti();
            ViewBag.IspitId = new SelectList(ispiti, "Id", "Naziv");
            var polagaje = _polaganja.GetPolaganje(id);
            return View();
        }

        // POST: PolaganjeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id, Ocena, OsvojenoBodova, RedniBrojPolaganja, UserId, IspitId")] Polaganje polaganje)
        {
            if (id == polaganje.Id)
            {
                try
                {
                    _polaganja.IzmeniPolaganje(id, polaganje);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();

        }

        // GET: PolaganjeController/Delete/5
        public ActionResult Delete(int id)
        {
            var polaganje = _polaganja.GetPolaganje(id);
            return View(polaganje);
        }

        // POST: PolaganjeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePolaganje(int id)
        {
            try
            {
                _polaganja.IzbrisiPolaganje(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
