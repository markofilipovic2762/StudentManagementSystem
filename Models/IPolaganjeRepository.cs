﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMS.Models
{
    public interface IPolaganjeRepository
    {
        void PrijaviIspit(int ispitId);
        IEnumerable<Polaganje> SvaPolaganja();
        Polaganje GetPolaganje(int id);
        void IzmeniPolaganje(int id, Polaganje polaganje);
        IEnumerable<Ispit> IspitiStudenta(string id);
        int PolozeniIspitiStudenta(string id);

        IEnumerable<Polaganje> MojaPolaganja();

        IEnumerable<Polaganje> PolaganjaKodProfesora();
        void SacuvajPolaganje(Polaganje polaganje);
        IEnumerable<Ispit> PolozeniIspitiKodProfesora(string id);
        void IzbrisiPolaganje(int id);

    }
}
