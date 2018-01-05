using System.Collections.Generic;

namespace TestAffichage.Model
{
    public class PosteDeCharge
    {
        public string Code { get; set; }
        public string Libellé { get; set; }
        public List<Machine> LesMachinesPdc { get; set; }
        public bool? Presence { get; set; }

        public PosteDeCharge(){}

        public PosteDeCharge(string code, string libellé, List<Machine> lesMachinesPdc)
        {
            this.Code = code;
            this.Libellé = libellé;
            this.LesMachinesPdc = lesMachinesPdc;
            this.Presence = null;
        }

        /*public static int ComparePdc(PosteDeCharge pdc1, PosteDeCharge pdc2) {
            return pdc1.Libellé.CompareTo(pdc2.Libellé);
        }*/

    }
}
