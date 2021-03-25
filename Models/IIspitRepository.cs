using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public interface IIspitRepository
    {
        IEnumerable<Ispit> SviIspiti();
        Ispit GetIspit(int id);
        void IzmeniIspit(int id, Ispit ispit);
        void SacuvajIspit(Ispit ispit);

        void IzbrisiIspit(int id);
    }
}
