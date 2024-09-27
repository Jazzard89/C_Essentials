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

namespace Snelheidsordening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] arrayNaam = new string[]
            {"Sandro Koninx", "Jo Bongaerts", "Paul Dox", "Patricia Briers", "Jan Bertels", "Lianne Thys"};
        int[] arraySnelheid = new int[]
            {1852, 1791, 1811, 1823, 1833, 1845};
        StringBuilder sb = new StringBuilder();
        int x;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            //get info & safe var
            for(int i = 0; i < arraySnelheid.Length; i++)
            {
                sb.AppendLine($"{arrayNaam[i]} - {arraySnelheid[i]}");
                txtResultaat.Text = Convert.ToString(sb);
            }
            

            txtName.Clear();
            txtAantalSeconde.Clear();
            txtName.Focus();
        }

        private void btnVolgorde_Click(object sender, RoutedEventArgs e)
        {
            for( int i = 0; i < arraySnelheid.Length; i++)
            {
                for (int x = 0; x < arraySnelheid.Length; x++)
                {
                        if (arraySnelheid[i] < arraySnelheid[x])
                        {
                        int snelste = arraySnelheid[x];
                        string snelsteNaam = arrayNaam[x];


                        //positie wissel
                        arraySnelheid[x] = arraySnelheid[i];
                        arrayNaam[x] = arrayNaam[i];


                        //voor iedere regel uitschrijven op array
                        arraySnelheid[i] = snelste;
                        arrayNaam[i] = snelsteNaam;

                        }
                }
            }



            for (int i = 0; i < arraySnelheid.Length; i++)
            {
                sb.AppendLine($"{arrayNaam[i]} - {arraySnelheid[i]}");
                txtResultaat.Text = Convert.ToString(sb);
            }

        }

        private void btnWissen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
