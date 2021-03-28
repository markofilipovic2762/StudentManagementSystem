using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public class PolaganjeRepository : IPolaganjeRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PolaganjeRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        public Polaganje GetPolaganje(int id)
        {
            var polaganje = _db.Polaganja.Include(p => p.User)
                .Include(r => r.Ispit)
                .Include(s => s.Ispit.Predmet).Where(t=> t.Id == id).SingleOrDefault();
            return polaganje;
        }

        public void IzmeniPolaganje(int id, Polaganje polaganje)
        {

            if(id == polaganje.Id)
            {
                _db.Update(polaganje);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Not compatible");
            }
            
        }

        public void SacuvajPolaganje(Polaganje polaganje)
        {

            //var polaganjeUBazi = _db.Polaganja.Single(p => p.Id == polaganje.Id);
            //polaganjeUBazi.Ocena = polaganje.Ocena;
            //polaganjeUBazi.OsvojenoBodova = polaganje.OsvojenoBodova;
            //polaganjeUBazi.RedniBrojPolaganja = polaganje.RedniBrojPolaganja;
            //polaganjeUBazi.Polozen = polaganje.Ocena > 5;

            //polaganjeUBazi.UserId = polaganje.UserId;
            //polaganjeUBazi.IspitId = polaganje.IspitId;
            polaganje.Polozen = polaganje.Ocena > 5;
            _db.Polaganja.Add(polaganje);
            _db.SaveChanges();
        }

        public IEnumerable<Polaganje> SvaPolaganja()
        {
            var svaPolaganja = _db.Polaganja.Include(t=> t.User)
                .Include(p => p.Ispit)
                .Include(c => c.Ispit.Predmet).ToList();
            return svaPolaganja;
        }

        public IEnumerable<Ispit> IspitiStudenta(string id)
        {
            var ispiti = _db.Polaganja
                .Include(s => s.User)
                .Include(p => p.Ispit)
                .Include(c => c.Ispit.Predmet)
                .Where(p => p.UserId == id).ToList();

            return (IEnumerable<Ispit>)ispiti;
        }

        public IEnumerable<Polaganje> PolozeniIspitiStudenta(string id)
        {
            var polozeniIspitiStudenta = _db.Polaganja
                .Include(s => s.User)
                .Include(p=> p.Ispit)
                .Include(r=> r.Ispit.Predmet)
                .Where(s => s.UserId == id && s.Ocena > 5)
                .ToList();

            return polozeniIspitiStudenta;
        }

        public IEnumerable<Polaganje> PolozeniIspitiKodProfesora(string id)
        {
           
               var ispiti = _db.Polaganja
                .Include(s => s.User)
                .Include(p => p.Ispit)
                .Include(c => c.Ispit.Predmet)
                .Where(p => p.Ocena > 5 && p.Ispit.Predmet.UserId == id)
                .ToList();

                return ispiti;
           
                
            

            //var profesor = _context.Users.SingleOrDefault(p => p.Id == idProfesora).Email;

            //ViewBag.Profesor = profesor;
            //return View(ispiti);
        }

        public void PrijaviIspit(int ispitId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Polaganje newPolaganje = new Polaganje { UserId = userId, IspitId = ispitId };
            _db.Polaganja.Add(newPolaganje);
            _db.SaveChanges();
        }

        public void IzbrisiPolaganje(int id)
        {
            var polaganje = _db.Polaganja.FirstOrDefault(s => s.Id == id);
            _db.Polaganja.Remove(polaganje);
            _db.SaveChanges();
        }

        public IEnumerable<Polaganje> MojaPolaganja()
        {
           var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var mojiIspiti = _db.Polaganja.Include(t => t.Ispit).Include(s => s.User)
                        .Include(c => c.Ispit.Predmet)
                        .Where(p => p.UserId == userId).ToList();
            return mojiIspiti;
        }

        public IEnumerable<Polaganje> PolaganjaKodProfesora()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var polaganjaKodProfesora = _db.Polaganja.Include(t => t.Ispit).Include(s => s.User)
                        .Include(c => c.Ispit.Predmet)
                        .Where(p => p.Ispit.Predmet.UserId == userId).ToList();
            return polaganjaKodProfesora;
        }
    }
}
