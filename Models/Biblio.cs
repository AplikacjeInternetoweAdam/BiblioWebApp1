using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiblioWebApp.Models
{
    public class Biblio
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Autor { get; set; }
        public string Opis { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; set; }

        public Biblio()
        {

        }
    }
}