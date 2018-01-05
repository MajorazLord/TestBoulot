using System;
using System.Collections.Generic;
using TestAffichage.Model;

namespace TestAffichage.ViewModel
{
    public class SaisieVM
    {
        public string SecteurCode { get; set; }
        public string SecteurLibellé { get; set; }
        public string Horaire { get; set; }
        public DateTime JourSaisie { get; set; }
        public List<PosteDeCharge> PdcsPrésents { get; set; }
        public List<PosteDeCharge> PdcsNonPrésents { get; set; }
        public List<PosteDeCharge> PdcsNonSaisie { get; set; }

        public SaisieVM(){}

        public SaisieVM(string secteurCode, string secteurLibellé, string horaire, DateTime jourSaisie, List<PosteDeCharge> pdcsPrésents, List<PosteDeCharge> pdcsNonPrésents, List<PosteDeCharge> pdcsNonSaisie)
        {
            SecteurCode = secteurCode;
            SecteurLibellé = secteurLibellé;
            Horaire = horaire;
            JourSaisie = jourSaisie;
            PdcsPrésents = pdcsPrésents;
            PdcsNonPrésents = pdcsNonPrésents;
            PdcsNonSaisie = pdcsNonSaisie;
        }
    }
}
