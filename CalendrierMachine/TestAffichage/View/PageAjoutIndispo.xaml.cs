using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TestAffichage.DataAccess;
using TestAffichage.ViewModel;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour PageAjoutIndispo.xaml
    /// </summary>
    public partial class PageAjoutIndispo : INotifyPropertyChanged
    {
        private PagePrincipale mainView;

        private ObservableCollection<IndisponibilitéVM> _lesIndisponibilités;
        public ObservableCollection<IndisponibilitéVM> LesIndisposSaisies
        {
            get { return _lesIndisponibilités; }
            set
            {
                _lesIndisponibilités = value;
                OnPropertyChanged("LesIndisposSaisies");
            }
        }
        public List<MachineVM> LesMachinesSelected { get; set; }
        private string _commentaire;
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

        public PageAjoutIndispo(PagePrincipale mainView)
        {
            InitializeComponent();
            DataContext = this;
            LesMachinesSelected = new List<MachineVM>();
            LesIndisposSaisies = new ObservableCollection<IndisponibilitéVM>();
            this.mainView = mainView;
        }

        private void BtnValider_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime dateSelectD = new DateTime();
            DateTime dateSelectF = new DateTime();
            if (DatePickD.SelectedDate != null && DatePickF.SelectedDate != null)
            {
                dateSelectD = (DateTime) DatePickD.SelectedDate;
                dateSelectF = (DateTime) DatePickF.SelectedDate;
            }
            else
            {
                MessageBox.Show("Erreur ! Merci de bien saisie les dates de début et de fin. (En cas de jour unique, saisir la même date en début et en fin.)","Erreur Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            bool requise = (bool) CbRequis.IsChecked;
            string comm = TbComm.Text;
            if (comm == "")
            {
                comm = " ";
            }
            CreationIndispos(LesMachinesSelected, dateSelectD, dateSelectF, requise, comm);
            ObservableCollection<AffichableEnListeBox> old = new ObservableCollection<AffichableEnListeBox>();
            old = mainView.LesElementsAAfficher;
            foreach (IndisponibilitéVM indis in LesIndisposSaisies)
            {
                old.Add(indis);
                DataBase.SaveIndispo(indis);
            }
            mainView.LesElementsAAfficher = old;
            mainView.AddItems();
            this.Close();
        }

        private void CreationIndispos(List<MachineVM> lesMachines, DateTime dateD, DateTime dateF, bool requise, string commentaire)
        {
            foreach (MachineVM machineVm in lesMachines)
            {
                LesIndisposSaisies.Add(new IndisponibilitéVM(machineVm.NoMachine, dateD, dateF, requise, commentaire));
            }
        }

        private void BtnSelection_OnClick(object sender, RoutedEventArgs e)
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

        private void BtnAnnuler_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Êtes-vous sur de vouloir annuler la saisie d'indisponibilité ?","Warning : Arret Saisie", MessageBoxButton.YesNo, MessageBoxImage.Information);
            //Debug.WriteLine(res);
            if (res == MessageBoxResult.Yes)
            {
                this.Close();    
            }
            
        }

        private void AfficherLesIndispos(ObservableCollection<AffichableEnListeBox> laListe)
        {
            foreach (AffichableEnListeBox element in laListe)
            {
                Debug.WriteLine(element.ToString());    
            }
        }

        private void TbComm_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            LbNbCar.Content = (250 - TbComm.Text.Length).ToString();
        }
    }
}
