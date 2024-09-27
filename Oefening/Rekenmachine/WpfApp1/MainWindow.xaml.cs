using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary
 
    public partial class MainWindow : Window
    {
        float getal1;
        float getal2;
        float resultaat;

        public MainWindow()
        {
            InitializeComponent();
            //Focus leggen op textblok
            TxtGetal1.Focus();
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            getal1 = Convert.ToSingle(TxtGetal1.Text);
            getal2 = float.Parse(TxtGetal2.Text);
            //berekeningen
            float uitkomst = getal1 + getal2;
            //tonen
            TxtResultaat.Text = Convert.ToString(uitkomst);
        }

        private void BtnMaal_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            getal1 = Convert.ToSingle(TxtGetal1.Text);
            getal2 = Convert.ToSingle(TxtGetal2.Text);
            //berekeningen
            float uitkomst = getal1 * getal2;
            //tonen
            TxtResultaat.Text = Convert.ToString(uitkomst);
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            getal1 = Convert.ToSingle(TxtGetal1.Text);
            getal2 = Convert.ToSingle(TxtGetal2.Text);
            //berekeningen
            float uitkomst = getal1 - getal2;
            //tonen
            TxtResultaat.Text = Convert.ToString(uitkomst);
        }

        private void BtnDelen_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            getal1 = Convert.ToSingle(TxtGetal1.Text);
            getal2 = Convert.ToSingle(TxtGetal2.Text);
            //berekeningen
            float uitkomst = getal1 / getal2;
            //tonen
            TxtResultaat.Text = Convert.ToString(uitkomst);
        }

        private void WissenBtn_Click(object sender, RoutedEventArgs e)

            //Read only van maken
        {
            TxtResultaat.Clear();
            TxtGetal1.Text = "";
            TxtGetal2.Text = "";
            TxtGetal1.Focus();
        }
    }
}
