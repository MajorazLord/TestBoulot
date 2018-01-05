using System;
using System.Collections.Generic;
using System.Windows;
using TestAffichage.DataAccess;
using TestAffichage.Model;
using TestAffichage.ViewModel;
using MessageBox = System.Windows.MessageBox;
using RadioButton = System.Windows.Controls.RadioButton;

namespace TestAffichage.View
{
    public partial class PagePresence : Window
    {
        public List<Secteur> Secteurs { get; set; }
        public SecteurVM SectSelected { get; set; }
        public PagePresenceVM ppvm;
        public UCSelect truc;
        public SecteurVM sectSelected;

        //Pour les resultats de la saisie :
        private string _horaire;
        private DateTime? _jourSaisie;
        private Secteur _secteurSaisie;
        private List<PosteDeCharge> _pdcPresent = new List<PosteDeCharge>();
        private List<PosteDeCharge> _pdcNonPresent = new List<PosteDeCharge>();
        private List<PosteDeCharge> _pdcNonSaisie = new List<PosteDeCharge>();
        
        public PagePresence()
        {
            InitializeComponent();
            _jourSaisie = DateTime.Now;
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            ppvm = new PagePresenceVM();
            this.DataContext = ppvm;
        }

        private void UCPresenceCtrl_OnChanged(object sender, RoutedEventArgs e)
        {
            sectSelected = (SecteurVM)this.CbChoixSecteur.SelectedItem;
            UCPresenceCtrl.DataContext = new SiteVM(new List<SecteurVM>(){sectSelected});
            RecupSecteurSaisie();
        }

        #region Recuperation du poste de saisie
        private string RecuperationHoraire()
        {
            List<RadioButton> _listRb = new List<RadioButton>();
            string horaire = "";
            _listRb.Add(Rb1);
            _listRb.Add(Rb2);
            _listRb.Add(Rb3);
            _listRb.Add(Rb4);
            _listRb.Add(Rb5);

            foreach (RadioButton rbToTest in _listRb)
            {
                if (rbToTest.IsChecked == true)
                {
                    switch (rbToTest.Name)
                    {

                        case "Rb1": horaire = "MAT"; break;
                        case "Rb2": horaire = "SOI"; break;
                        case "Rb3": horaire = "NUI"; break;
                        case "Rb4": horaire = "WE1"; break;
                        case "Rb5": horaire = "WE2"; break;
                        default: break;
                    }
                }                
            }
            if (horaire.Equals(""))
            {
                MessageBox.Show("Merci de bien vouloir selectionner votre poste", "Erreur Saisie Poste", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                return "";
            }
            else
            {
                return horaire;
            }
        }
        #endregion

        private DateTime? RecuperationJourSaisie()
        {
            if (DatePickerJours.SelectedDate == null)
            {
                MessageBox.Show("Merci de bien vouloir selectionner la date du jour de la saisie", "Erreur Saisie Jour",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return DatePickerJours.SelectedDate;
        }

        #region Recuperer uniquement les pdcs pour le secteur selectionné
        private void RecupResultatCheck()
        {
            _pdcNonPresent.Clear();
            _pdcPresent.Clear();
            _pdcNonSaisie.Clear();
            foreach (PosteDeChargeVM pdcToTest in sectSelected.Children)
            {
                switch (pdcToTest.Presence)
                {
                    case true:
                        _pdcPresent.Add(new PosteDeCharge(pdcToTest.Code,pdcToTest.Libellé,pdcToTest.LesMachinesPdc));
                        break;
                    case false:
                        _pdcNonPresent.Add(new PosteDeCharge(pdcToTest.Code, pdcToTest.Libellé, pdcToTest.LesMachinesPdc));
                        break;
                    case null:
                        _pdcNonSaisie.Add(new PosteDeCharge(pdcToTest.Code, pdcToTest.Libellé, pdcToTest.LesMachinesPdc));
                        break;
                }
            }
        }
        #endregion

        #region Récuperer le secteur seclectionné pour la saisie
        private void RecupSecteurSaisie()
        {
            _secteurSaisie = new Secteur(sectSelected.Code, sectSelected.Libellé, sectSelected.LesPdcsSecteurs);
            //Debug.WriteLine(_secteurSaisie);
        }
        #endregion

        #region Action OnClick BTnConfirmerSelect
        private void BtnConfirmerSelect_OnClick(object sender, RoutedEventArgs e)
        {
            string resultat = "";
            if (sectSelected == null)
            {
                MessageBox.Show("Merci de saisir un secteur et d'effectuer une saisie avant de valider.",
                    "Erreur validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (sectSelected.Children.Count == 1)
            {
                sectSelected.IsExpanded = true;
                return;
            }
            _horaire = RecuperationHoraire();
            _jourSaisie = RecuperationJourSaisie();
            RecupResultatCheck();
            RecupSecteurSaisie();
            if (_horaire != "" && _jourSaisie != null)
            {
                List<SaisieVM> saisieToSave = BuildSaisieVM();
                if (MainWindow.IsConnected())
                {
                    resultat = DataBase.VerifAddOrUpdate(saisieToSave);
                    bool res = DataBase.SaveSaisieVMToBDD_TR(saisieToSave, resultat);

                    if (res)
                    {
                        MessageBox.Show("Saisie Sauvegardée !", "Sauvegarde Reussi", MessageBoxButton.OK, MessageBoxImage.None);                 
                    }
                }
                else
                {
                    MessageBox.Show("Erreur WIFI, Merci de vous rapprocher d'une borne wifi pour établir une connection.", "Erreur Sauvegarde Wifi", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
        #endregion

        #region Creation d'une liste de SaisieVM pour la sauvegarde en local
        private List<SaisieVM> BuildSaisieVM()
        {
            return new List<SaisieVM>()
            {
                new SaisieVM(_secteurSaisie.Code, _secteurSaisie.Libellé, _horaire, (DateTime) _jourSaisie, _pdcPresent, _pdcNonPresent, _pdcNonSaisie)
            };
        }
        #endregion

        #region Alerte sur la date lors des horaires standards
        private void Rb3_Rb5_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime heureSaisie = DateTime.Now;
            //DateTime heureSaisie = new DateTime(2017,11,20,6,32,0);
            if (Verif_NUI_MMJV(heureSaisie) || Verif_NUI_WE2_SD(heureSaisie) || Verif_WE2_L(heureSaisie))
            {
                MessageBox.Show("Attention à bien choisir la date du jour (date du début de poste)","", MessageBoxButton.OK, MessageBoxImage.Warning);    
            }
        }
        
        //Gère le cas des NUI (mardi, mercredi, jeudi et vendredi entre 00h et 5h)
        private bool Verif_NUI_MMJV(DateTime infoJour)
        {
            return infoJour.Hour >= 00 && infoJour.Hour <= 4 &&
                   (infoJour.DayOfWeek != DayOfWeek.Monday || infoJour.DayOfWeek != DayOfWeek.Saturday ||
                    infoJour.DayOfWeek != DayOfWeek.Sunday);
        }
        
        //Gère le cas de la NUI (samedi entre 00h et 2h) et du WE2 (dimanche entre 00h et 2h)  
        private bool Verif_NUI_WE2_SD(DateTime infoJour)
        {
            return (infoJour.DayOfWeek == DayOfWeek.Saturday || infoJour.DayOfWeek == DayOfWeek.Sunday) && infoJour.Hour >= 00 && infoJour.Hour <= 2;
        }
        
        //Gère le cas du WE2 (lundi entre 00h et 6h30)
        private bool Verif_WE2_L(DateTime infoJour)
        {
            return infoJour.DayOfWeek == DayOfWeek.Monday && infoJour.Hour >= 00 && (infoJour.Hour < 6 || (infoJour.Hour == 6 && infoJour.Minute <= 30));
        }
        #endregion
    }
}
