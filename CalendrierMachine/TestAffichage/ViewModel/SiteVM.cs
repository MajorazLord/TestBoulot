using System.Collections.Generic;
using System.Linq;
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
