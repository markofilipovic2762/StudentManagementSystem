using Microsoft.EntityFrameworkCore;
using StudentMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public class PredmetRepository : IPredmetRepository
    {
        private readonly ApplicationDbContext _db;

        public PredmetRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Predmet GetPredmet(int id)
        {
            return _db.Predmeti.Include(t => t.User).FirstOrDefault(i => i.id == id);
        }

        public void IzbrisiPredmet(int id)
        {
            var predmet = _db.Predmeti.Find(id);
            _db.Predmeti.Remove(predmet);
            _db.SaveChanges();
        }

        public void IzmeniPredmet(int id)
        {
            var predmet = _db.Predmeti.Find(id);
            _db.Predmeti.Update(predmet);
            _db.SaveChanges();
        }

        public void SacuvajPredmet(Predmet predmet)
        {
            _db.Predmeti.Add(predmet);
            _db.SaveChanges();
        }

        public IEnumerable <Predmet> SviPredmeti()
        {
            var sviPredmeti = _db.Predmeti.Include(p => p.User).ToList();
            return sviPredmeti;
        }
    }
}
