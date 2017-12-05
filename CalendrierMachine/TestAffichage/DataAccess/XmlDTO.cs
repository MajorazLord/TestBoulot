using System;
using System.Collections.Generic;
using TestAffichage.Model;
using TestAffichage.ViewModel;

namespace TestAffichage.DataAccess
{
    [Serializable]
    public class XmlSaisieVM
    {
        public string SecteurCode { get; set; }
        public string SecteurLibellé { get; set; }
        public string Horaire { get; set; }
        public DateTime JourSaisie { get; set; }
        public List<PosteDeCharge> PdcsPrésents { get; set; }
        public List<PosteDeCharge> PdcsNonPrésents { get; set; }
    }

    public class XmlSaisieVMConverter
    {

        public List<XmlSaisieVM> ConvertListToXml(IEnumerable<SaisieVM> saisieVMs)
        {
            List<XmlSaisieVM> xmlSaisieVMs = new List<XmlSaisieVM>();
            foreach (SaisieVM c in saisieVMs)
            {
                xmlSaisieVMs.Add(this.ConvertSaisieVMToXml(c));
            }
            return xmlSaisieVMs;
        }

        public XmlSaisieVM ConvertSaisieVMToXml(SaisieVM saisieVM)
        {
            return new XmlSaisieVM()
            {
                SecteurCode = saisieVM.SecteurCode,
                SecteurLibellé = saisieVM.SecteurLibellé,
                Horaire = saisieVM.Horaire,
                JourSaisie = saisieVM.JourSaisie,
                PdcsPrésents = saisieVM.PdcsPrésents,
                PdcsNonPrésents = saisieVM.PdcsNonPrésents
            };
            
        }

        public List<SaisieVM> ConvertXmlToList(List<XmlSaisieVM> xmlSaisieVMs)
        {
            List<SaisieVM> commandables = new List<SaisieVM>();
            foreach (XmlSaisieVM xc in xmlSaisieVMs)
            {
                commandables.Add(this.ConvertXmlToSaisieVM(xc));
            }
            return commandables;
        }

        public SaisieVM ConvertXmlToSaisieVM(XmlSaisieVM xmlSaisieVM)
        {
            return new SaisieVM(
                xmlSaisieVM.SecteurCode,
                xmlSaisieVM.SecteurLibellé,
                xmlSaisieVM.Horaire,
                xmlSaisieVM.JourSaisie,
                xmlSaisieVM.PdcsPrésents,
                xmlSaisieVM.PdcsNonPrésents
            );
           
        }
    }



}
