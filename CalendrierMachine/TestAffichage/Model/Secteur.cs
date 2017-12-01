using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAffichage.Model
{
    public class Secteur
    {
        public string Libellé { get; private set; }
        public string Code { get; set; }
        public List<PosteDeCharge> LesPdcsSecteurs { get; set; }

        public Secteur(){}

        public Secteur(string code, string libellé, List<PosteDeCharge> lesPdcsSecteurs)
        {
            this.Libellé = libellé;
            this.Code = code;
            this.LesPdcsSecteurs = lesPdcsSecteurs;
        }

        public override string ToString()
        {
            return "Libellé : " + Libellé + "\nCode : " + Code;
        }
    }
}
