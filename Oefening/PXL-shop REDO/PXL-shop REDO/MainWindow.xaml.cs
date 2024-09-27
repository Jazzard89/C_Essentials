using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PXL_shop_REDO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer klok = new DispatcherTimer();
        StringBuilder aankoopResultaat = new StringBuilder();
        StringBuilder totaalPrijsBuilder = new StringBuilder();
        Random rnd = new Random();

        double totaalPrijs;

        string naam;
        int hoeveelheid;
        double prijs;
        string hoeveelheidstring;


        public MainWindow()
        {
            InitializeComponent();
            klok.Tick += new EventHandler(klokAfgelopen);
            klok.Interval = new TimeSpan(0, 0, 1);
            klok.Start();
            RandomBackground();
        }

        private void klokAfgelopen(object sender, EventArgs e)
        {
            txtTimeShow.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnVoegToe_Click(object sender, RoutedEventArgs e)
        {
            //lees velden uit
            naam = txtNaam.Text;
            hoeveelheid = Convert.ToInt32(txtHoeveelheid.Text);
            prijs = Convert.ToInt32(txtPrijs.Text);

            //bereken totaal
            totaalPrijs = totaalPrijs + (hoeveelheid * prijs);

            //schrijf resultaat op string
            aankoopResultaat.AppendLine($"{naam} - {hoeveelheid}");
            txtOutput.Text = aankoopResultaat.ToString();


            //verwijder vorige resultaat
            totaalPrijsBuilder.Clear();


        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            KaderResultaat();
        }

        private void btnNieuweBestelling_Click(object sender, RoutedEventArgs e)
        {
            txtHoeveelheid.Clear();
            txtNaam.Clear();
            txtOutput.Clear();
            txtPrijs.Clear();

            naam = null;
            hoeveelheidstring = null;
            hoeveelheid = 0;
            prijs = 0;
            totaalPrijs = 0;
            aankoopResultaat.Clear();
        }

        private void KaderResultaat()
        {
            //schrijf vorige string
            aankoopResultaat.AppendLine($"{naam} - {hoeveelheid}");
            txtOutput.Text = aankoopResultaat.ToString();

            //schrijf string bovenkant
            totaalPrijsBuilder.AppendLine(" ");
            totaalPrijsBuilder.AppendLine();


            ////////////////////////////////////////////////////////////////////////////////////////////
            ////schrijf kader/////////////////////////////////////////////////////////////////////////////
            ///


            totaalPrijsBuilder.AppendLine($"{totaalPrijs:c}");
            totaalPrijsBuilder.AppendLine();
            totaalPrijsBuilder.AppendLine("PXL - Shop");

            //schrijf resultaat op string


            txtOutput.Text = aankoopResultaat.ToString() + totaalPrijsBuilder.ToString();
        }


        private void RandomBackground()
        {
            int backgroundSwitcher = rnd.Next(1, 3);

            switch (backgroundSwitcher)
            {
                case 1:
                    backgroundapp.Background = Brushes.LimeGreen;
                    break;
                case 2:
                    backgroundapp.Background= Brushes.LightGreen;
                    break;

                default:
                    break;
            }
        }
    }
}
