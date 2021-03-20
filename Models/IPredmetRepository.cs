using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public interface IPredmetRepository
    {
        IEnumerable<Predmet> SviPredmeti();
        Predmet GetPredmet(int id);
        void IzmeniPredmet(int id);
        void SacuvajPredmet(Predmet predmet);
        void IzbrisiPredmet(int id);
    }
}
