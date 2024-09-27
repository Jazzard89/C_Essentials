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

namespace Oefening15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string snelsteNaam;
        int snelsteTijd = int.MaxValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            //get info & safe var
            if (Int32.Parse(txtAantalSeconde.Text) < snelsteTijd)
                    {
                    int tijdelijkeTijd = Int32.Parse(txtAantalSeconde.Text);
                    snelsteTijd = tijdelijkeTijd;
                    snelsteNaam = Convert.ToString(txtName.Text);
                    }

            txtName.Clear();
            txtAantalSeconde.Clear();
            txtName.Focus();
        }

        private void btnSnelste_Click(object sender, RoutedEventArgs e)
        {
            //schrijf code
            //txtResultaat.Text = $"De snlste loper is {snelsteNaam}\n;" +
                                //$"\nMet een tijd van {snelsteTijd}\n";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"De snelste atleet is {snelsteNaam}");
            sb.AppendLine($"Totaal aantal seconde: {snelsteTijd}");
            int uren = snelsteTijd / 3600;
            snelsteTijd -= (uren * 3600);
            int minuten = snelsteTijd / 60;
            snelsteTijd -= (minuten * 60);
            int seconde = snelsteTijd;

            sb.AppendLine($"Aantal uren: {uren}");
            sb.AppendLine($"Aantal minuten: {minuten}");
            sb.AppendLine($"Aantal seconde: {seconde}");
            txtResultaat.Text = sb.ToString();
        }
    }

}




