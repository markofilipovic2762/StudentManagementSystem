using Microsoft.EntityFrameworkCore;
using StudentMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public class PolaganjeRepository : IPolaganjeRepository
    {
        private readonly ApplicationDbContext _db;
        public PolaganjeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Polaganje GetPolaganje(int id)
        {
            var polaganje = _db.Polaganja.Include(p => p.User)
                .Include(r => r.Ispit)
                .Include(s => s.Ispit.Predmet).Where(t=> t.Id == id);
            return (Polaganje)polaganje;
        }

        public void IzmeniPolaganje(int id)
        {
            var polaganje = _db.Polaganja.Find(id);
            _db.Polaganja.Update(polaganje);
            _db.SaveChanges();
        }

        public void SacuvajPolaganje(Polaganje polaganje)
        {

            var polaganjeUBazi = _db.Polaganja.Single(p => p.Id == polaganje.Id);
            polaganjeUBazi.Ocena = polaganje.Ocena;
            polaganjeUBazi.OsvojenoBodova = polaganje.OsvojenoBodova;
            polaganjeUBazi.RedniBrojPolaganja = polaganje.RedniBrojPolaganja;
            polaganjeUBazi.Polozen = polaganje.Ocena > 5;

            polaganjeUBazi.UserId = polaganje.UserId;
            polaganjeUBazi.IspitId = polaganje.IspitId;
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

        public int PolozeniIspitiStudenta(string id)
        {
            var brojPolozenihIspita = _db.Polaganja
                .Include(s => s.User)
                .Include(p=> p.Ispit)
                .Include(r=> r.Ispit.Predmet)
                .Where(s => s.UserId == id && s.Ocena > 5).Count();
            return brojPolozenihIspita;
        }

        public IEnumerable<Ispit> PolozeniIspitiKodProfesora(string id)
        {
           
               var ispiti = _db.Polaganja
                .Include(s => s.User)
                .Include(p => p.Ispit)
                .Include(c => c.Ispit.Predmet)
                .Where(p => p.Ocena > 5 && p.Ispit.Predmet.UserId == id)
                .ToList();

                return (IEnumerable<Ispit>)ispiti;
           
                
            

            //var profesor = _context.Users.SingleOrDefault(p => p.Id == idProfesora).Email;

            //ViewBag.Profesor = profesor;
            //return View(ispiti);
        }
    }
}
