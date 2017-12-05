using System;
using System.Collections.Generic;

namespace TestAffichage.Model
{
    public class Exception
    {
        private List<Machine> _lesMachines;
        private DateTime _date;
        private string _poste;
        private DateTime _heureD;
        private DateTime _heureF;

        public Exception(){}

        public Exception(List<Machine> lesMachines, DateTime date, string poste, DateTime heureD, DateTime heureF)
        {
            this._lesMachines = lesMachines;
            this._date = date;
            this._poste = poste;
            this._heureD = heureD;
            this._heureF = heureF;
        }
    }
}
