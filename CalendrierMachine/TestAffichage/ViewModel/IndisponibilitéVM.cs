using System;

namespace TestAffichage.ViewModel
{
    public class IndisponibilitéVM : AffichableEnListeBox
    {
        public string NoMachineIndispo { get; set; }
        public DateTime DateSaisieD { get; set; }
        public DateTime DateSaisieF { get; set; } 
        public bool Requise { get; set; }
        public string Commentaire { get; set; }

        public IndisponibilitéVM(string noMachineIndispo, DateTime dateSaisieD, DateTime dateSaisieF, bool requise, string commentaire)
        {
            NoMachineIndispo = noMachineIndispo;
            DateSaisieD = dateSaisieD;
            DateSaisieF = dateSaisieF;
            Requise = requise;
            Commentaire = commentaire;
        }

        public override string ToString()
        {
            return String.Format("{0} | {1:d} | {2:d} | {3} | {4}", NoMachineIndispo, DateSaisieD, DateSaisieF, Requise, Commentaire);
        }
    }
}
