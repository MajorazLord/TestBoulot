using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using TestAffichage.ViewModel;

namespace TestAffichage.View
{
    /// <summary>
    /// Logique d'interaction pour UCSelect.xaml
    /// </summary>
    public partial class UCPresence : UserControl
    {
        public UCPresence()
        {
            InitializeComponent();
        }

        private void Rb_OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rbRes = (RadioButton)sender;
            PosteDeChargeVM pdcSender = (PosteDeChargeVM) ((Grid) ((StackPanel) rbRes.Parent).Parent).DataContext;
            if (rbRes.Name.Equals("RbOui"))
            {
                Debug.WriteLine("RbOUI " + pdcSender.Code);
                pdcSender.Presence = true;
            }
            if (rbRes.Name.Equals("RbNon"))
            {
                Debug.WriteLine("RbNON" + pdcSender.Code);
                pdcSender.Presence = false;
            }
        }
    }
}
