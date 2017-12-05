using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TestAffichage.DataAccess;
using TestAffichage.Properties;
using TestAffichage.ViewModel;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour PageParametre.xaml
    /// </summary>
    public partial class PageRepetitionExep : Window, INotifyPropertyChanged
    {
        private PageModification _pmBase;

        private DateTime _dateBase;
        public DateTime DateBase
        {
            get
            {
                return _dateBase;
            }
            private set
            {
                _dateBase = value;
                OnPropertyChanged("DateBase");
            }
        }
        
        private DateTime _dateFin;
        public DateTime DateFin
        {
            get
            {
                return _dateFin;
            }
            private set
            {
                _dateFin = value;
                OnPropertyChanged("DateFin");
            }
        }

        public PageRepetitionExep(PageModification pm)
        {
            DateBase = pm.DateDuJour;
            _pmBase = pm;
            DataContext = this;
            InitializeComponent();
        }

        private void ToggleBOuiNon_OnClick(object sender, RoutedEventArgs e)
        {
            S1.Visibility = ToggleBOuiNon.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
            L1.Visibility = ToggleBOuiNon.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
            L2.Visibility = ToggleBOuiNon.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
            LbDate2.Visibility = ToggleBOuiNon.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
            Lb2.Visibility = ToggleBOuiNon.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
            Tb2.Visibility = ToggleBOuiNon.IsChecked == true ? Visibility.Visible : Visibility.Hidden;
            if (S1.Visibility == Visibility.Hidden)
            {
                S1.Value = 1;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Tb2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb2.Text == "")
            {
                DateFin = DateBase;
            }
            else
            {
                DateFin = DateBase.AddDays(7 * int.Parse(Tb2.Text));    
            }
            
        }

        private void BtnAnnuler_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Êtes-vous sur de vouloir annuler la saisie d'exception ?","Warning : Arret Saisie", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (res == MessageBoxResult.Yes)
            {
                this.Close();    
            }
            
            
        }

        private void BtnValider_OnClick(object sender, RoutedEventArgs e)
        {
            List<ExceptionVM> listDeBase = _pmBase.LesExceptionsToSave;

            if (ToggleBOuiNon.IsChecked == false)
            {
                DataBase.SaveExceptionInBDD(listDeBase);
            }
            else
            {
                List<ExceptionVM> listFinalToSave = new List<ExceptionVM>();
                int week = int.Parse(Tb2.Text);
                foreach (ExceptionVM exceptionVm in listDeBase)
                {
                    listFinalToSave.Add(exceptionVm);
                    int x = 0;
                    while (week != x)
                    {
                        x += 1;
                        listFinalToSave.Add(new ExceptionVM(exceptionVm.LesMachines, DateBase.AddDays(7 * x), exceptionVm.Poste, exceptionVm.HeureD, exceptionVm.HeureF));
                    }
                }
                DataBase.SaveExceptionInBDD(listFinalToSave);
            }
            this.Close();
        }
    }
}
