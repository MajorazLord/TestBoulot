using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using TestAffichage.DataAccess;
using TestAffichage.Utils;
using TestAffichage.ViewModel;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class PagePrincipale : INotifyPropertyChanged
    {
        private ObservableCollection<AffichableEnListeBox> _lesElements;
        public ObservableCollection<AffichableEnListeBox> LesElementsAAfficher
        {
            get { return _lesElements; }
            set
            {
                _lesElements = value;
                OnPropertyChanged("LesElementsAAfficher");
                //LboxDetail.Items.Refresh();
            }
        }
        
        private ObservableCollection<AffichableEnListeBox> _lesElementsB;
        public ObservableCollection<AffichableEnListeBox> LesElementsAAfficherB
        {
            get { return _lesElementsB; }
            set
            {
                _lesElementsB = value;
                OnPropertyChanged("LesElementsAAfficherB");
                //LboxDetail.Items.Refresh();
            }
        }

        private DateTime _laDate;

        public DateTime LaDate
        {
            get { return _laDate; }
            set
            {
                _laDate = value;
                OnPropertyChanged("LaDate");
            }
        }

        public PagePrincipale()
        {
            this.Resources["selector"] = new DataTemplateSelectorExample(this);
            InitializeComponent();
            LaDate = DateTime.Today;
            LesElementsAAfficher = DataBase.ChargerIndisposExcepts();
            LesElementsAAfficherB = LesElementsAAfficher;
            //this.DataContext = this;
            this.LboxDetail.DataContext = this;
            TbRech.TextChanged += new TextChangedEventHandler(textBox1_TextChanged);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine(LaDate);
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BtnAddIndispo_OnClick(object sender, RoutedEventArgs e)
        {
            PageAjoutIndispo pai = new PageAjoutIndispo(this);
            pai.ShowDialog();
        }

        private void BtnAddExept_OnClick(object sender, RoutedEventArgs e)
        {
            PageModification pm = new PageModification(this);
            pm.ShowDialog();
        }

        private void CalendrierSelect_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            LaDate = (DateTime) CalendrierSelect.SelectedDate;
            CbIndispos_OnClick(sender,e);
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddItems();
        }

        public void AddItems()
        {
            LesElementsAAfficher.Clear();
            AjusterLesElements();
            if (TbRech.Text == "")
            {
                LesElementsAAfficher = LesElementsAAfficherB;
            }
            else
            {
                foreach (AffichableEnListeBox alb in LesElementsAAfficherB)
                {
                    if (alb is ExceptionUVM)
                    {
                        if (((ExceptionUVM)alb).NoMachine.ToString().ToUpper().StartsWith(TbRech.Text.ToUpper()))
                        {
                            LesElementsAAfficher.Add(alb);
                        }
                    }
                    if (alb is IndisponibilitéVM)
                    {
                        if (((IndisponibilitéVM)alb).NoMachineIndispo.ToString().ToUpper().StartsWith(TbRech.Text.ToUpper()))
                        {
                            LesElementsAAfficher.Add(alb);
                        }
                    }

                }    
            }
        }


        /// <summary>
        /// Permet de lacher le focus sur le calendrier sinon il faut double clicker après avoir une date.
        /// Le If 'is button' sert a laisser le fonctionnement du changement de mois, sinon on ne peut plus changer les mois
        /// </summary>
        private void CalendrierSelect_OnGotMouseCapture(object sender, MouseEventArgs e)
        {
            UIElement originalElement = e.OriginalSource as UIElement;
            if (originalElement != null)
            {
                if (originalElement is Button)
                {

                }
                else
                {
                    originalElement.ReleaseMouseCapture();
                }
            }
        }

        private void BtnCom_OnClick(object sender, RoutedEventArgs e)
        {
            Grid g = ((Button)sender).Parent as Grid;
            if (g.Name == "MyGrid")
            {
                Debug.WriteLine(g.DataContext);
            }
            string texte = ((IndisponibilitéVM) g.DataContext).Commentaire;
            MessageBox.Show("\tCommentaire : \n\n"+texte,"Commentaire", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void MenuSupprIndispo_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            ContextMenu cm = mi.Parent as ContextMenu;
            Popup p = cm.Parent as Popup;
            Grid g = p.PlacementTarget as Grid;
            if (g.Name == "MyGrid")
            {
                DataBase.DeleteElementAAfficher(g.DataContext as IndisponibilitéVM);
                int res = LesElementsAAfficher.IndexOf(g.DataContext as IndisponibilitéVM);
                LesElementsAAfficher.RemoveAt(res);
            }
        }

        private void MenuSupprExcepts_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            ContextMenu cm = mi.Parent as ContextMenu;
            Popup p = cm.Parent as Popup;
            Grid g = p.PlacementTarget as Grid;
            if (g.Name == "MyGrid")
            {
                DataBase.DeleteElementAAfficher(g.DataContext as ExceptionUVM);
                int res = LesElementsAAfficher.IndexOf(g.DataContext as ExceptionUVM);
                LesElementsAAfficher.RemoveAt(res);
            }
        }

        private void CbIndispos_OnClick(object sender, RoutedEventArgs e)
        {
            AddItems();
            //AjusterLesElements();
        }

        public void AjusterLesElements()
        {
            //Affiche tout pour tout les jours
            if (CbExepts.IsChecked == true && CbIndispos.IsChecked == true && RbGlobal.IsChecked == true)
            {
                LesElementsAAfficherB = DataBase.ChargerIndisposExcepts();
            }
            //Affiche les exceptions pour tout les jours
            if (CbExepts.IsChecked == true && CbIndispos.IsChecked == false && RbGlobal.IsChecked == true)
            {
                LesElementsAAfficherB = DataBase.ChargerExceptsDepuisBDD();
            }
            //Affiche les indisponibilités pour tout les jours
            if (CbExepts.IsChecked == false && CbIndispos.IsChecked == true && RbGlobal.IsChecked == true)
            {
                LesElementsAAfficherB = DataBase.ChargerIndisposDepuisBDD();
            }
            //Affiche rien, rien de selectionné sauf "tout les jours"
            if (CbExepts.IsChecked == false && CbIndispos.IsChecked == false && RbGlobal.IsChecked == true)
            {
                LesElementsAAfficherB = new ObservableCollection<AffichableEnListeBox>();
            }
            //Affiche les indisponibilités du jour saisie sur le calendrier
            if (RbGlobal.IsChecked == false && CbExepts.IsChecked == false && CbIndispos.IsChecked == true)
            {
                LesElementsAAfficherB = new ObservableCollection<AffichableEnListeBox>();
                LesElementsAAfficherB = DataBase.ChargeIndispoDate(LaDate);
            } 
            //Affiche les exceptions du jour saisie sur le calendrier
            if (RbGlobal.IsChecked == false && CbExepts.IsChecked == true && CbIndispos.IsChecked == false)
            {
                LesElementsAAfficherB = new ObservableCollection<AffichableEnListeBox>();
                LesElementsAAfficherB = DataBase.ChargeExceptDate(LaDate);
            }
            //Affiche tout pour le jour saisie sur le calendrier
            if (RbGlobal.IsChecked == false && CbExepts.IsChecked == true && CbIndispos.IsChecked == true)
            {
                LesElementsAAfficherB = new ObservableCollection<AffichableEnListeBox>();
                LesElementsAAfficherB = DataBase.ChargerIndisposExceptsDate(LaDate);
            }
            //Affiche rien, rien de cocher
            if (RbGlobal.IsChecked == false && CbExepts.IsChecked == false && CbIndispos.IsChecked == false)
            {
                LesElementsAAfficherB = new ObservableCollection<AffichableEnListeBox>();
            }
        }
    }
}
