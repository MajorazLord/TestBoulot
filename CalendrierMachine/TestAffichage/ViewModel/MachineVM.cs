using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAffichage.Model;
using Exception = TestAffichage.Model.Exception;

namespace TestAffichage.ViewModel
{
    public class MachineVM : TreeViewItemVM
    {
        private readonly Machine _machine;

        public MachineVM(Machine machine, PosteDeChargeVM parent) : base(parent, false)
        {
            _machine = machine;
        }

        public bool IsInitiallySelected { get; private set; }

        public string NoMachine
        {
            get { return _machine.NoMachine; }
        }
        public string Libellé
        {
            get { return _machine.Libellé; }
        }
        public List<Indisponibilité> LesIndiposMachine
        {
            get { return _machine.LesIndisposMachine; }
        }
        public List<Exception> LesExceptionsMachine
        {
            get { return _machine.LesExeptionsMachine; }
        }
        public string CodeOuverture
        {
            get { return _machine.CodeOuverture; }
        }
        public int Charge
        {
            get { return _machine.Charge; }
        }
    }

}
