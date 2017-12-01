using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestAffichage.ViewModel
{
    public class ExceptionUVM : AffichableEnListeBox, INotifyPropertyChanged
    {
        private string _noMachine;
        public string NoMachine
        {
            get { return _noMachine; }
            set
            {
                _noMachine = value;
                OnPropertyChanged("NoMachine");
            }
        }
        
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        private string _poste;
        public string Poste
        {
            get { return _poste; }
            set
            {
                _poste = value;
                OnPropertyChanged("Poste");
            }
        }

        private TimeSpan _heureD;
        public TimeSpan HeureD
        {
            get { return _heureD; }
            set
            {
                _heureD = value;
                OnPropertyChanged("HeureD");
            }
        }

        private TimeSpan _heureF;
        public TimeSpan HeureF
        {
            get { return _heureF; }
            set
            {
                _heureF = value;
                OnPropertyChanged("HeureF");
            }
        }

        public ExceptionUVM(){}

        public ExceptionUVM(string noMachines, DateTime date, string poste, TimeSpan heureD, TimeSpan heureF)
        {
            _noMachine = noMachines;
            _date = date;
            _poste = poste;
            _heureD = heureD;
            _heureF = heureF;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
