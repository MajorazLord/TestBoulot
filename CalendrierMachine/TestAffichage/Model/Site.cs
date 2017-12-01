using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAffichage.Model
{
    public class Site
    {
        public string Nom { get; set; }
        public List<Secteur> Secteurs { get; set; }

        public Site(){}

        public Site(string nom, List<Secteur> secteurs)
        {
            Nom = nom;
            Secteurs = secteurs;
        }
    }
}
