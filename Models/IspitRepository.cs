using Microsoft.EntityFrameworkCore;
using StudentMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public class IspitRepository : IIspitRepository
    {
        private readonly ApplicationDbContext _db;
        public IspitRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Ispit GetIspit(int id)
        {
            return _db.Ispiti.Include(p=> p.Predmet).FirstOrDefault(t => t.Id == id);
        }

        public void IzbrisiIspit(int id)
        {
            var ispit = _db.Ispiti.Find(id);
            if (ispit != null)
            {
                _db.Ispiti.Remove(ispit);
                _db.SaveChanges();
                
            }
        }

        public void IzmeniIspit(int id)
        {
            var ispit = _db.Ispiti.SingleOrDefault(i => i.Id == id);
            if(ispit != null)
            {
                _db.Ispiti.Update(ispit);
                _db.SaveChanges();
            }
        }

        public void SacuvajIspit(Ispit ispit)
        {
            _db.Ispiti.Add(ispit);
            _db.SaveChanges();
        }


        public IEnumerable<Ispit> SviIspiti()
        {
            return _db.Ispiti.Include(p => p.Predmet).ToList();
        }
    }
}
