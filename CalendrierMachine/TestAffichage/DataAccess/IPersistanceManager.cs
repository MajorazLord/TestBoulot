using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAffichage.ViewModel;

namespace TestAffichage.DataAccess
{
    public interface IPersistanceManager
    {
        void Save(List<SaisieVM> listeSaisieVM, string nomFichier);
        List<SaisieVM> Load(string nomFichier);
    }
}
