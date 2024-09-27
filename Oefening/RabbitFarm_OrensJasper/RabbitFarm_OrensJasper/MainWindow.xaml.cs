using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;

namespace RabbitFarm_OrensJasper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int huizenAantal;
        int veldenAantal;
        int maandenAantal;
        int capaciteit;
        double populatie;
        int populatieNew;
        int counter;
        int counterMaanden;
        const double multiplier = 0.5d;
        StringBuilder populatiegroei = new StringBuilder();




        public MainWindow()
        {
            InitializeComponent();
            txtHuizen.Focus();
        }

        private void btnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lees tekst velden uit
                huizenAantal = Convert.ToInt32(txtHuizen.Text);
                veldenAantal = Convert.ToInt32(txtVelden.Text);

                //huis *40 en veld *100
                if (huizenAantal == 0)
                {
                    capaciteit = veldenAantal * 100;
                }
                else if (veldenAantal == 0)
                {
                    capaciteit = huizenAantal * 40;
                }
                else
                {
                    capaciteit = (huizenAantal * 40) + (veldenAantal * 100);
                }
            }

            catch(FormatException)
            {
                //voeg symbool toe
                
                MessageBox.Show("Not in correct format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }

            txtOutput.Text = ($"De totale capaciteit van je boerderij is {Convert.ToString(capaciteit)} konijnen");

            btnSimulatie.IsEnabled = true;
        }








        private void btnSimulatie_Click(object sender, RoutedEventArgs e)
        {

            populatie = Convert.ToDouble(txtSprong.Text);
            maandenAantal = Convert.ToInt32(txtMaanden.Text);



            counter = 1;
            counterMaanden = 1;

            //vul string aan

                while (counter != maandenAantal + 1)
                {
                    if (counter > 3)
                    {
                        populatie = (populatie * multiplier) + populatie;


                        while (populatie > capaciteit)
                        {

                        populatie = capaciteit;

                        }

                }





                    populatiegroei.AppendLine($"Aantal Maanden {counter} Huidige populatie is {Convert.ToInt32(populatie)}");
                    //schrijf string
                    txtOutput.Text = Convert.ToString(populatiegroei);

                    counter++;
                }

                //schrijf string
                txtOutput.Text = Convert.ToString(populatiegroei);
            }

        private void btnWissen_Click(object sender, RoutedEventArgs e)
        {
            txtHuizen.Clear();
            txtMaanden.Clear();
            txtOutput.Clear();
            txtSprong.Clear();
            txtVelden.Clear();

            populatiegroei.Clear();

            huizenAantal = 0;
            veldenAantal = 0;
            maandenAantal = 0;
            capaciteit = 0;
            populatie = 0;
        }


    }
}
