using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Controllers
{
    public class IspitController : Controller
    {
        private readonly IIspitRepository _ispiti;
        private readonly IPredmetRepository _predmeti;
        public IspitController(IIspitRepository ispiti, IPredmetRepository predmeti)
        {
            _ispiti = ispiti;
            _predmeti = predmeti;
        }
        // GET: IspitController
        public ActionResult Index()
        {
            return View(_ispiti.SviIspiti());
        }

        // GET: IspitController/Details/5
        public ActionResult Details(int id)
        {
            var ispit = _ispiti.GetIspit(id);
            return View(ispit);
        }

        // GET: IspitController/Create
        public ActionResult Create()
        {
            var predmeti = _predmeti.SviPredmeti();
            ViewBag.PredmetId = new SelectList(predmeti, "id", "Naziv");
            return View();
        }

        // POST: IspitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id, DatumIspita, PredmetId")] Ispit ispit)
        {
            var predmeti = _predmeti.SviPredmeti();
            ViewBag.PredmetId = new SelectList(predmeti, "id", "Naziv", ispit.PredmetId);
            try
            {
                _ispiti.SacuvajIspit(ispit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ispit);
            }
        }

        // GET: IspitController/Edit/5
        public ActionResult Edit(int id)
        {
            var predmeti = _predmeti.SviPredmeti();
            var predmet = _predmeti.GetPredmet(id);
            ViewBag.PredmetId = new SelectList(predmeti, "id", "Naziv");
            return View(predmet);
        }

        // POST: IspitController/Edit/5
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditIspit(int id, Ispit ispit)
        {
            var predmeti = _predmeti.SviPredmeti();
            ViewBag.PredmetId = new SelectList(predmeti, "id", "Naziv", ispit.PredmetId);
            try
            {
                _ispiti.IzmeniIspit(id, ispit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ispit);
            }
        }

        // GET: IspitController/Delete/5
        public ActionResult Delete(int id)
        {
            var ispit = _ispiti.GetIspit(id);
            return View(ispit);
        }

        // POST: IspitController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIspit(int id)
        {
            try
            {
                _ispiti.IzbrisiIspit(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
