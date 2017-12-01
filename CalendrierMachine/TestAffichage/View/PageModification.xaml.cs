using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestAffichage.DataAccess;
using TestAffichage.ViewModel;
using Exception = TestAffichage.Model.Exception;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour PageModification.xaml
    /// </summary>
    public partial class PageModification : INotifyPropertyChanged
    {
        private PagePrincipale _mainView;
        public Label LbChiffre;
        private DateTime _dateDuJour;
        public DateTime DateDuJour
        {
            get { return _dateDuJour; }
            private set
            {
                _dateDuJour = value;
                OnPropertyChanged("DateDuJour");
            }
        }

        private TextBox tbH1;

        public List<MachineVM> LesMachinesSelected { get; set; }
        private int _nbMachines;
        public int NbMachinesSelected
        {
            get { return _nbMachines; }
            set
            {
                _nbMachines = value;
                OnPropertyChanged("NbMachinesSelected");
            }
        }

        private static readonly List<string> postesSemaine = new List<string>() { "MAT", "SOI", "NUI" };
        private static readonly List<string> postesWEJF = new List<string>() { "MAT", "SOI", "NUI", "WE1", "WE2" };

        private List<string> _lesPostes = new List<string>();
        public List<string> LesPostes
        {
            get { return _lesPostes; }
            set
            {
                _lesPostes = value;
                OnPropertyChanged("LesPostes");
            }
        }


        public PageModification(PagePrincipale mainView)
        {
            InitializeComponent();
            DataContext = this;
            LbChiffre = LbNbMSelected;
            DateDuJour = (DateTime)mainView.LaDate;
            _mainView = mainView;
            if (DateDuJour.DayOfWeek == DayOfWeek.Saturday || DateDuJour.DayOfWeek == DayOfWeek.Sunday)
            {
                LesPostes = postesWEJF;
            }
            else
            {
                LesPostes = postesSemaine;    
            }
            
        }

        private void BtnAnnuler_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSelecMachines_OnClick(object sender, RoutedEventArgs e)
        {
            PageSelection ps = new PageSelection(this);
            ps.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /*private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(TimeSpan.FromHours(SlHD.Value).ToString(@"hh\:mm"));
        }*/

        private void ToggleBOuiNon_OnClick(object sender, RoutedEventArgs e)
        {
            if (ToggleBOuiNon.IsChecked == false)
            {
                CbPoste1.SelectedItem = null;
                CbPoste2.SelectedItem = null;
                CbPoste3.SelectedItem = null;
            }
            if (DateDuJour.DayOfWeek == DayOfWeek.Saturday || DateDuJour.DayOfWeek == DayOfWeek.Sunday)
            {
                LesPostes = postesWEJF;
            }
            else
            {
                LesPostes = ToggleBOuiNon.IsChecked == true ? postesWEJF : postesSemaine;    
            }
        }

        private void BtnValider_OnClick(object sender, RoutedEventArgs e)

        {
            if (NbMachinesSelected == 0)
            {
                MessageBox.Show("Merci de saisir au moins une machine !", "Erreur Machines", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            List<ExceptionVM> lesExceptionsToSave = new List<ExceptionVM>();
            if(VerifContenuSaisie()){
                ExceptionVM exeptToSave1 = new ExceptionVM(LesMachinesSelected, DateDuJour,
                    CbPoste1.SelectedItem.ToString(), new TimeSpan(int.Parse(Tb1D1.Text), int.Parse(Tb1D2.Text), 0),
                    new TimeSpan(int.Parse(Tb1F1.Text), int.Parse(Tb1F2.Text), 0));
                ExceptionVM exeptToSave2 = new ExceptionVM(LesMachinesSelected, DateDuJour,
                    CbPoste2.SelectedItem.ToString(), new TimeSpan(int.Parse(Tb2D1.Text), int.Parse(Tb2D2.Text), 0),
                    new TimeSpan(int.Parse(Tb2F1.Text), int.Parse(Tb2F2.Text), 0));

                lesExceptionsToSave.Add(exeptToSave1);
                lesExceptionsToSave.Add(exeptToSave2);

                if (CbPoste3.SelectedItem != null)
                {
                    ExceptionVM exeptToSave3 = new ExceptionVM(LesMachinesSelected, DateDuJour,
                        CbPoste3.SelectedItem.ToString(), new TimeSpan(int.Parse(Tb3D1.Text), int.Parse(Tb3D2.Text), 0),
                        new TimeSpan(int.Parse(Tb3F1.Text), int.Parse(Tb3F2.Text), 0));
                    lesExceptionsToSave.Add(exeptToSave3);
                }
                DataBase.SaveExceptionInBDD(lesExceptionsToSave);
            }
            /*foreach (ExceptionVM exceptionVm in lesExceptionsToSave)
            {
                foreach (MachineVM machineVm in exceptionVm.LesMachines)
                {
                    _mainView.LesElementsAAfficher.Add(new ExceptionUVM(machineVm.NoMachine, exceptionVm.Date, exceptionVm.Poste, exceptionVm.HeureD, exceptionVm.HeureF));
                }
            }*/
            _mainView.AddItems();
            this.Close();
            
        }

        private bool VerifContenuSaisie()
        {
            bool res1, res2, res3;

            #region Poste 1
            if (Tb1D1.Text == "" || Tb1F1.Text == "" || Tb1D2.Text == "" || Tb1F2.Text == "" ||
                CbPoste1.SelectedItem == null)
            {
                MessageBox.Show(
                    "Merci de vérifier votre saisie pour le poste 1 \n(Poste non selectionné ou horaire non saisie)",
                    "Erreur Saisie Poste 1", MessageBoxButton.OK, MessageBoxImage.Warning);
                res1 = false;
            }
            else
            {
                res1 = true;
            }
            #endregion

            #region Poste 2
            if (Tb2D1.Text == "" || Tb2F1.Text == "" || Tb2D2.Text == "" || Tb2F2.Text == "" || CbPoste2.SelectedItem == null)
            {
                MessageBox.Show("Merci de vérifier votre saisie pour le poste 2 \n(Poste non selectionné ou horaire non saisie)",
                    "Erreur Saisie Poste 2", MessageBoxButton.OK, MessageBoxImage.Warning);
                res2 = false;
            }
            else
            {
                res2 = true;
            }
            #endregion
            
            #region Poste 3
            if (Tb3D1.Text == "" || Tb3F1.Text == "" || Tb3D2.Text == "" || Tb3F2.Text == "" || CbPoste3.SelectedItem == null)
            {
                MessageBoxResult mbr = MessageBox.Show("Merci de vérifier votre saisie pour le poste 3\n(Poste non selectionné ou horaire non saisie)\n\nVoulez vous confirmer la saisie ?\nSi ce choix est volontaire (deux postes dans la journée), cliquez sur OUI",
                    "Erreur Saisie Poste 3", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (mbr == MessageBoxResult.Yes)
                {
                    res3 = true;
                }
                else
                {
                    res3 = false;
                }
            }
            else
            {
                res3 = true;
            }
            #endregion

            return res1 && res2 && res3;
        }

        private void Tb1F1_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
