using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour PageParametre.xaml
    /// </summary>
    public partial class PageParametre : Window
    {
        public PageParametre()
        {
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
        }

        
    }
}
