using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestAffichage.ViewModel;

namespace TestAffichage.DataAccess
{
    class PersistanceManagerXML : IPersistanceManager
    {
        private XmlSerializer xs;
        private XmlSaisieVMConverter xmlConverter;

        public PersistanceManagerXML()
        {
            xs = new XmlSerializer(typeof(List<XmlSaisieVM>));
            xmlConverter = new XmlSaisieVMConverter();
        }

        public void Save(List<SaisieVM> listeSaisieVM, string nomFichier)
        {
            StreamWriter sw = new StreamWriter(nomFichier);
            List<XmlSaisieVM> listXmlSaisieVM = xmlConverter.ConvertListToXml(listeSaisieVM);
            this.xs.Serialize(sw, listXmlSaisieVM);
            sw.Close();
        }
        
        public List<SaisieVM> Load(string nomFichier)
        {
            try
            {
                StreamReader sw = new StreamReader(nomFichier);
                List<XmlSaisieVM> l = this.xs.Deserialize(sw) as List<XmlSaisieVM>;
                sw.Close();
                return l != null ? xmlConverter.ConvertXmlToList(l) : new List<SaisieVM>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<SaisieVM>();
            }
        }
    }
}
