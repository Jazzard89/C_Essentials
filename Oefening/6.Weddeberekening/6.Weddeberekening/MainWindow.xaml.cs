using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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

namespace _6.Weddeberekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //set vars
        float brutoLoon;
        float aantalUren;
        float nettoLoon;
        const string stdAantalUren = "1686";
        const string stdUurLoon = "17,85";
        const string stdPersoneelsLidNaam = "naam";




        public MainWindow()
        {
            InitializeComponent();

            //declaratie tekstveld
            TxtPersoneelslid.Text = stdPersoneelsLidNaam;
            TxtAantalUren.Text = stdAantalUren;
            TxtUurloon.Text = stdUurLoon;

        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            //afsluiten (mag ook .Close(); zijn)
            this.Close();
        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            //Wissen
            TxtPersoneelslid.Text = stdPersoneelsLidNaam;
            TxtResultaat.Clear();
            //oorspronkelijk plaatsen
            TxtAantalUren.Text = stdAantalUren;
            TxtUurloon.Text = stdUurLoon;
        }





        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            //lezen (uurloon moet Tryparse zijn om geen text input)
            bool isGelukt = float.TryParse(TxtUurloon.Text, out float uurLoon);
            aantalUren = Convert.ToSingle(TxtAantalUren.Text);
            if (isGelukt == true)
            {



                //brutoloon berekenen
                float belasting = 0;
            brutoLoon = uurLoon * aantalUren;


                if (brutoLoon <= 10000)
                {
                    //belasting = 0%
                    belasting = 0;
                }
                else if (brutoLoon <= 15000)
                {
                    //belastingen = 20%
                    belasting = ((brutoLoon - 10000) * 0.2f);
                }
                else if (brutoLoon <= 25000)
                {
                    belasting = ((brutoLoon - 1000) * 0.3f) + 1000;
                }
                else if (brutoLoon <= 50000)
                {
                    belasting = ((brutoLoon - 25000) * 0.4f) + 3000 + 1000;
                }

            // Moeten eindigen op else, en niet op else if
                else
                {
                    belasting = ((brutoLoon - 5000) * 0.5f) + 10000 + 3000 + 1000;
                }


                //schrijven ( op deze manier kunnen we met " werken als er $ staat, \n is een nieuwe regel)
                TxtResultaat.Text = $"LOONFICHE VAN {TxtPersoneelslid.Text}\n;" +
                $"\nAantal gewerkte uren: {TxtAantalUren.Text}" +
                $"\n Uurloon: {uurLoon:c}" +
                $"\n Brutojaarwedde: {brutoLoon:c}" +
                $"Belasting: {belasting:c}\n";
            }
        }
    }
}
