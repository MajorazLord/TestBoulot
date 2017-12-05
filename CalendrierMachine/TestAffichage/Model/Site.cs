using System.Collections.Generic;

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
