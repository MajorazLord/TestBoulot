using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using TestAffichage.DataAccess;
using TestAffichage.Model;
using TestAffichage.ViewModel;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour PageParam.xaml
    /// </summary>
    public partial class PageParam : Window
    {
        public PageParam()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            List<SecteurVM> lesSecteurs =  DataBase.GetsSecteursBDD("MONTLUCON");
            foreach (var lesSecteur in lesSecteurs)
            {
                Debug.WriteLine(lesSecteur.ToString());
            }
        }
    }
}
