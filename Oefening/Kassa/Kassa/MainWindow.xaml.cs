using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Kassa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnControleNummer_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            float ondernemingsNummer = Convert.ToSingle(TxtOndernemingsnummer.Text);
            string controleNummer = Convert.ToString(TxtControlenummer.Text);
            //berekenen
            const float controleCijfer = 97;
            float controleX = ondernemingsNummer % controleCijfer;
            float controleY = controleCijfer - controleX;
            //schrijven
            TxtControlenummer.Text = Convert.ToString(controleY);

            //if (TxtControlenummer = 
        }

        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            float prijs = Convert.ToSingle(TxtPrijs.Text);
            float aantal = Convert.ToSingle(TxtAantal.Text);
            //berekenen
            float teBetalen = prijs * aantal;
            //schrijven
            TxtTeBetalen.Text = Convert.ToString(teBetalen);
        }


        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            TxtAantal.Clear();
            TxtControlenummer.Clear();
            TxtOndernemingsnummer.Clear();
            TxtPrijs.Clear();
            TxtTeBetalen.Clear();
        }


        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}