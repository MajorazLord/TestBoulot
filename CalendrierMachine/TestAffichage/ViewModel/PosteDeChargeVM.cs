using System.Collections.Generic;
using TestAffichage.DataAccess;
using TestAffichage.Model;

namespace TestAffichage.ViewModel
{
    public class PosteDeChargeVM : TreeViewItemVM
    {
        private readonly PosteDeCharge _pdc;

        public PosteDeChargeVM(PosteDeCharge pdc, SecteurVM parent) : base(parent, true)
        {
            _pdc = pdc;
        }
        public bool IsInitiallySelected { get; private set; }
        public string Code
        {
            get { return _pdc.Code; }
        }
        public string Libellé
        {
            get { return _pdc.Libellé; }
        }

        public bool? Presence
        {
            get { return _pdc.Presence; }
            set { _pdc.Presence = value; }
        }



        public List<Machine> LesMachinesPdc
        {
            get { return _pdc.LesMachinesPdc; }
        }

        public override void LoadChildren()
        {
            foreach (Machine machine in DataBase.GetsMachinesBDD(_pdc))
                    base.Children.Add(new MachineVM(machine, this));
            
        }
    }
}
