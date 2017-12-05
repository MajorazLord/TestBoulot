using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestAffichage.DataAccess;

namespace TestAffichage.ViewModel
{
    public class PagePresenceVM : INotifyPropertyChanged
    {
        public SiteVM _currentVm;
        public SiteVM CurrentViewModel
        {
            get { return _currentVm; }
            set
            {
                _currentVm = value;
                this.NotifyPropertyChanged("CurrentViewModel");
            }
        }

        public DateTime DatePresence { get; set; }

        public List<SecteurVM> currentSect;

        public List<SecteurVM> CurrentSect { get; set; }

        public PagePresenceVM()
        {
            CurrentViewModel = new SiteVM(DataBase.GetsAllSecteursBDD());
            CurrentSect = CurrentViewModel.Secteurs;
            DatePresence = DateTime.Now;
        }

        
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));    
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

