using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using TestAffichage.DataAccess;
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
