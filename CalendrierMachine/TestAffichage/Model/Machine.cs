using System.Collections.Generic;

namespace TestAffichage.Model
{
    public class Machine
    {
        public string NoMachine { get; set; }
        public string Libellé { get; set; }
        public List<Indisponibilité> LesIndisposMachine { get; set; }
        public List<Exception> LesExeptionsMachine { get; set; }
        public string CodeOuverture { get; set; }
        public int Charge { get; set; }//en heures

        public Machine(){}

        public Machine(string noMachine, string libellé, List<Indisponibilité> lesIndisposMachine, 
            List<Exception> lesExeptionsMachine, string codeOuverture, int charge)
        {
            this.NoMachine = noMachine;
            this.Libellé = libellé;
            this.LesIndisposMachine = lesIndisposMachine;
            this.LesExeptionsMachine = lesExeptionsMachine;
            this.CodeOuverture = codeOuverture;
            this.Charge = charge;
        }
    }
}
