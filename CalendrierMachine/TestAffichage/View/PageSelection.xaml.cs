using System.Collections.Generic;
using System.Windows;
using TestAffichage.DataAccess;
using TestAffichage.ViewModel;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour PageSelection.xaml
    /// </summary>
    public partial class PageSelection : Window
    {
        public SiteVM ViewModel;
        private Window _mainView;

        private List<MachineVM> _listeDesMachines;

        public PageSelection(Window mainView)
        {
            InitializeComponent();
            if (mainView is PageAjoutIndispo)
            {
                _mainView = (PageAjoutIndispo)mainView;    
            }
            else if(mainView is PageModification)
            {
                _mainView = (PageModification) mainView;
            }
            List<SecteurVM> secteurs = DataBase.GetsAllSecteursBDD();
            ViewModel = new SiteVM(secteurs);
            this.Fenetre.DataContext = ViewModel;

            CBcheckall.IsChecked = true;
            _listeDesMachines = initMachines();



            CBcheckall.IsChecked = false;
        }

        private List<MachineVM> initMachines()
        {
            List<MachineVM> listMachine = new List<MachineVM>();
            foreach (var sect in ViewModel.Secteurs)
            {
                foreach (var pdc in sect.Children)
                {
                    foreach (var treeViewItemVm in pdc.Children)
                    {
                        if (treeViewItemVm is MachineVM)
                        {
                            listMachine.Add((MachineVM)treeViewItemVm);
                        }
                    }
                }
            }
            return listMachine;
        }

        private List<MachineVM> FindMachines(string nomachine)
        {
            List<MachineVM> listMachine = new List<MachineVM>();
            bool ok = false;
            foreach (var sect in ViewModel.Secteurs)
            {
                sect.IsExpanded = true;
                foreach (var pdc in sect.Children)
                {
                    pdc.IsExpanded = true;
                    foreach (var treeViewItemVm in pdc.Children)
                    {
                        if (treeViewItemVm is MachineVM)
                        {
                            if (((MachineVM) treeViewItemVm).NoMachine == nomachine)
                            {
                                treeViewItemVm.IsExpanded = true;
                                ok = true;
                            }
                        }
                    }
                    pdc.IsExpanded = false;
                    if (ok == true)
                    {
                        pdc.IsExpanded = true;
                        break;
                    }
                }
                sect.IsExpanded = false;
                if (ok == true)
                {
                    sect.IsExpanded = true;
                    break;
                }
            }
            return listMachine;
        }

        private void BtnConfirmerSelect_OnClick(object sender, RoutedEventArgs e)
        {
            List<MachineVM> listMachineSelect = new List<MachineVM>();
            foreach (var sect in ViewModel.Secteurs)
            {
                foreach (var pdc in sect.Children)
                {
                    foreach (var treeViewItemVm in pdc.Children)
                    {
                        if(treeViewItemVm is MachineVM){
                            if (treeViewItemVm.IsChecked == true)
                            {
                                listMachineSelect.Add((MachineVM)treeViewItemVm);    
                            }
                            //Debug.WriteLine("Machine :" + ((MachineVM)treeViewItemVm).NoMachine + " -> " + ((MachineVM)treeViewItemVm).IsChecked);
                        }
                    }
                }
            }
            if (_mainView is PageAjoutIndispo)
            {
                ((PageAjoutIndispo) _mainView).LesMachinesSelected = listMachineSelect;
                ((PageAjoutIndispo) _mainView).NbMachinesSelected = listMachineSelect.Count;
            }
            else if(_mainView is PageModification)
            {
                ((PageModification) _mainView).LesMachinesSelected = listMachineSelect;
                ((PageModification) _mainView).NbMachinesSelected = listMachineSelect.Count;
            }
            
            this.Close();
        }

        private void CBcheckall_OnChecked(object sender, RoutedEventArgs e)
        {
            foreach (var truc in ViewModel.Secteurs)
            {
                truc.IsExpanded = true;
                foreach (var pdc in truc.Children)
                {
                    pdc.IsExpanded = true;
                    foreach (MachineVM machine in pdc.Children)
                    {
                        machine.IsChecked = CBcheckall.IsChecked.Value;
                    }
                    pdc.IsExpanded = CBcheckall.IsChecked.Value;
                }
                truc.IsExpanded = CBcheckall.IsChecked.Value;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            FindMachines(TbChercher.Text);
        }
    }
}
