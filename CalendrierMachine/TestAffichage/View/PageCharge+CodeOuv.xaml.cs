using System;
using System.Collections.Generic;
using System.Windows;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour PageCharge_CodeOuv.xaml
    /// </summary>
    public partial class PageCharge_CodeOuv : Window
    {
        private readonly List<string> _dataSource = new List<string> { "1x8", "2x8", "3x8", "4x8", "5x8" };
            
        public PageCharge_CodeOuv()
        {
            InitializeComponent();

            CbJanvCodeOuv.ItemsSource = _dataSource;
            CbFevrCodeOuv.ItemsSource = _dataSource;
            CbMarsCodeOuv.ItemsSource = _dataSource;
            CbAvrilCodeOuv.ItemsSource = _dataSource;
            CbMaiCodeOuv.ItemsSource = _dataSource;
            CbJuinCodeOuv.ItemsSource = _dataSource;
            CbJuilCodeOuv.ItemsSource = _dataSource;
            CbAoutCodeOuv.ItemsSource = _dataSource;
            CbSeptCodeOuv.ItemsSource = _dataSource;
            CbOctoCodeOuv.ItemsSource = _dataSource;
            CbNoveCodeOuv.ItemsSource = _dataSource;
            CbDeceCodeOuv.ItemsSource = _dataSource;
        }


        private void BtnSelect_OnClick(object sender, RoutedEventArgs e)
        {
            /*PageSelection ps = new PageSelection();
            ps.ShowDialog();*/
        }

        private void BtnAnnuler_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnValider_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
