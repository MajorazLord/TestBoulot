using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TestAffichage.ViewModel
{
    public class TreeViewItemVM : INotifyPropertyChanged
    {

        #region Data

        static readonly TreeViewItemVM DummyChild = new TreeViewItemVM();

        List<TreeViewItemVM> _children;
        readonly TreeViewItemVM _parent;
       
        
        private bool _isExpanded = false;
        private bool _isSelected = false;
        private bool? _isChecked = false;

        #endregion // Data

        #region Constructors

        protected TreeViewItemVM(TreeViewItemVM parent, bool lazyLoadChildren)
        {
            _parent = parent;

            _children = new List<TreeViewItemVM>();

            if (lazyLoadChildren)
                _children.Add(DummyChild);
        }

        public  TreeViewItemVM()
        {
            _children = new List<TreeViewItemVM>();
        }

        #endregion

        #region Presentation Members

        #region Children
        public List<TreeViewItemVM> Children
        {
            get { return _children; } 
            set { _children = value; }
        }

        #endregion

        #region HasLoadedChildren
        public bool HasDummyChild
        {
            get { return this.Children.Count == 1 && this.Children[0] == DummyChild; }
        }

        #endregion

        #region IsExpanded
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (MainWindow.IsConnected())
                {
                    if (value != _isExpanded)
                    {
                        _isExpanded = value;
                        this.RaisePropertyChanged("IsExpanded");
                    }

                    // Expand all the way up to the root.
                    if (_isExpanded && _parent != null)
                        _parent.IsExpanded = true;

                    // Lazy load the child items, if necessary.
                    if (this.HasDummyChild || this.Children.Count == 0)
                    {
                        this.Children.Remove(DummyChild);
                        if (this.Children.Count == 0)
                        {
                            this.LoadChildren();        
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Impossible de charger les données, connection WIFI non établie !",
                        "Erreur Wifi : Chargement Pdc", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #endregion 

        #region IsSelected
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.RaisePropertyChanged("IsSelected");
                }
            }
        }

        #endregion

        #region IsChecked
        public bool? IsChecked
        {
            get { return _isChecked; }
            set
            {
                this.SetIsChecked(value, true, true);
            }
        }

        void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            
            if (this.HasDummyChild)
            {
                IsExpanded = true;
            }

            if (value == _isChecked)
                return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue)
                this.Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));
            
            if (updateParent && _parent != null)
                _parent.VerifyCheckState();

            this.RaisePropertyChanged("IsChecked");
        }

        void VerifyCheckState()
        {
            bool? state = null;
            for (int i = 0; i < this.Children.Count; ++i)
            {
                bool? current = this.Children[i].IsChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }
            this.SetIsChecked(state, false, true);
        }

        #endregion

        #region LoadChildren
        public virtual void LoadChildren()
        {
        }
        #endregion

        #region Parent
        public TreeViewItemVM Parent
        {
            get { return _parent; }
        }
        #endregion

        #endregion

        #region INotifyPropertyChanged Members

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
