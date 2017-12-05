using System.Collections.Generic;
using TestAffichage.ViewModel;

namespace TestAffichage.DataAccess
{
    public interface IPersistanceManager
    {
        void Save(List<SaisieVM> listeSaisieVM, string nomFichier);
        List<SaisieVM> Load(string nomFichier);
    }
}
