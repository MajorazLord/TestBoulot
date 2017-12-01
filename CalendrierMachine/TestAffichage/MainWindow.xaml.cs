using System;
using System.Runtime.InteropServices;
using System.Windows;
using TestAffichage.DataAccess;
using TestAffichage.View;
using MessageBox = System.Windows.MessageBox;

namespace TestAffichage
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPresence_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsConnected())
            {
                PagePresence pp = new PagePresence();
                pp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Erreur ! Merci de bien vouloir connecter le support au réseau WIFI", "ERREUR WIFI", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        [DllImport("wininet.dll")]
        public static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        // Utilisation de l'API 
        public static bool IsConnected()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        private void BtnCalendrier_OnClick(object sender, RoutedEventArgs e)
        {
            PagePrincipale pP = new PagePrincipale();
            pP.ShowDialog();
        }

        private void BtnCharge_OnClick(object sender, RoutedEventArgs e)
        {
            PageCharge_CodeOuv pcc = new PageCharge_CodeOuv();
            pcc.ShowDialog();
        }

        private void BtnSem_OnClick(object sender, RoutedEventArgs e)
        {
            //Remplie la table MACHINES_CALENDRIER par defaut jusqu'a fin 2025
            DataBase.TotalTest(new DateTime(2017,11,20), new DateTime(2025,12,28));
        }
    }
}
