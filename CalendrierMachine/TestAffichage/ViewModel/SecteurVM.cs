using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAffichage.DataAccess;
using TestAffichage.Model;

namespace TestAffichage.ViewModel
{
    public class SecteurVM : TreeViewItemVM
    {
        private Secteur _secteur;


        public SecteurVM(Secteur secteur) : base(null, true)
        {
            _secteur = secteur;
            LesPdcsSecteurs = new List<PosteDeCharge>();
        }
        public bool IsInitiallySelected { get; private set; }

        public string Code
        {
            get { return _secteur.Code; }
            set { _secteur.Code = value; }
        }
        public string Libellé
        {
            get { return _secteur.Libellé; }
        }
        public List<PosteDeCharge> LesPdcsSecteurs { get; set; }

        public override void LoadChildren()
        {
            foreach (PosteDeCharge pdc in DataBase.GetsPosteDeChargesBDD(_secteur))
            {
                base.Children.Add(new PosteDeChargeVM(pdc, this));
                //base.Children.OrderBy(t => ((PosteDeChargeVM) t).Libellé);
                LesPdcsSecteurs.Add(pdc);
            }
        }

       

    }
}
