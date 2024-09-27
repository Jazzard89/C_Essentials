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

namespace Rabbit_Farm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            int huis = 40;
            int veld = 100;
            

        public MainWindow()
        {
            InitializeComponent();  
        }

        private void BtnBereken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int huisaantal = Convert.ToInt16(TxtHuis.Text);
                int huiscap = huisaantal * huis;

                int veldaantal = Convert.ToInt16(TxtVeld.Text);
                int veldcap = veldaantal * veld;

                TxtResultaat.Text = $"De totale capaciteit van je boerderij is {veldcap + huiscap} konijnen";
            }
            catch (Exception)
            {
                MessageBox.Show ("Ongeldige input in aantal huizen of aantal velden.", "Ongeldige input", MessageBoxButton.OK, MessageBoxImage.Error);
            }        
        }

        private void BtnSimulatie_Click(object sender, RoutedEventArgs e)
        {
            //controle of alle velden zijn ingevuld
            if (int.TryParse(TxtHuis.Text, out int aantalhuizen)
                && int.TryParse(TxtVeld.Text, out int aantalveld)
                && int.TryParse(TxtMaand.Text, out int aantalmaanden)
                && double.TryParse(TxtSprong.Text, out double groottesprong))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i<= aantalmaanden; i++)
                {
                    if(i > 3)
                    {
                        groottesprong = Math.Floor(1.5 * groottesprong);
                        groottesprong = Math.Min(groottesprong, aantalhuizen * 40 + aantalveld * 100);
                    }
                    sb.AppendLine($"maand {i}: {groottesprong}");
                }
                TxtResultaat.Text = sb.ToString();
            }
            else
            {
                MessageBox.Show ("Ongeldige input in aantal huizen, aantal velden, aantal maanden of grootte sprong.", "Ongeldige input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            TxtHuis.Text = "0";
            TxtMaand.Text = "0";
            TxtResultaat.Text = "";
            TxtSprong.Text = "0";
            TxtVeld.Text = "0";
        }
    }
}
