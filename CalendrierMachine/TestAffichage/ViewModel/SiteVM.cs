using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAffichage.Model;

namespace TestAffichage.ViewModel
{
    public class SiteVM
    {
        public Site modelSite;
        public bool IsInitiallySelected { get; private set; }
        public List<SecteurVM> Secteurs { get; set; }

        public SiteVM()
        {
        }

        public SiteVM(List<SecteurVM> secteurs)
        {
            Secteurs = new List<SecteurVM>(
                (from secteur in secteurs
                    select secteur)
                .ToList());
        }

        
    }
}
