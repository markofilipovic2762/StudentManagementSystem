using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public interface IPolaganjeRepository
    {
        IEnumerable<Polaganje> SvaPolaganja();
        Polaganje GetPolaganje(int id);
        void IzmeniPolaganje(int id);
        IEnumerable<Ispit> IspitiStudenta(string id);
        int PolozeniIspitiStudenta(string id);
        void SacuvajPolaganje(Polaganje polaganje);
        IEnumerable<Ispit> PolozeniIspitiKodProfesora(string id);
    }
}
