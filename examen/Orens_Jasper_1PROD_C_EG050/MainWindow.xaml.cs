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

namespace Orens_Jasper_1PROD_C_EG050
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer klok = new DispatcherTimer();
        Dictionary<string, bool> isVogelGespot = new Dictionary<string, bool>();
        int vogelTeller;
        string[,] vogels = {
            {"Dodaars","Futen", "Niet bedreigd", "2"},
            {"Tureluur","Strandlopers", "Niet bedreigd", "2"},
            {"Wulp", "Strandlopers", "Gevoelig", "5"},
            {"Grutto", "Strandlopers", "Gevoelig", "6"},
            {"Roerdomp", "Reigers", "Niet bedreigd", "3"},
            {"Blauwe Reiger", "Reigers", "Niet bedreigd", "4"},
            {"Woudaap", "Reigers", "Niet bedreigd", "2"} };
        string naam;
        string email;
        string richting;
        int gekozenVogel;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            klok.Tick += new EventHandler(klokAfgelopen);
            klok.Interval = new TimeSpan(0, 0, 1);
            klok.Start();
            ToonTijd();
            LaadDictionary();
            LaadVogelsInCombobox();




        }
        private void klokAfgelopen(object sender, EventArgs e)
        {
            ToonTijd();
        }

        private void ToonTijd()
        {
            TxtTijd.Text = $"{DateTime.Now.ToLongTimeString()}";
        }

        private void LaadDictionary()
        {
            //Read out all items in one listbox 
            for (int k = 0; k < vogels.GetLength(0); k++)
            {
                if (vogels[k, 0] != null)
                {
                    isVogelGespot.Add(vogels[k, 0], false);
                }
            }
        }

        private void LaadVogelsInCombobox()
        {
            //Read out all items in one listbox 
            for (int k = 0; k < vogels.GetLength(0); k++)
            {
                if (vogels[k, 0] != null)
                {
                    CbTeSpottenVogels.Items.Add(vogels[k, 0]);
                }
            }
        }


        private void Closing_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Vooruitgang(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRegistreer_Click(object sender, RoutedEventArgs e)
        {
            //naam opvangen
            //TxtNaam.Background = string.IsNullOrWhiteSpace(TxtNaam.Text)
            if ((TxtNaam.Text.Contains(" ") == false) && (TxtNaam.Text != ""))
            {
                naam = TxtNaam.Text;
                //email adres opvangen
                //note to self bekijk hoe ik pxl ook kan opvangen met hoofdletters
                if ((TxtEmail.Text.Contains("@") == true) && (TxtEmail.Text.Contains("pxl.be") == true))
                {
                    email = TxtEmail.Text;

                    RadioButtons();
                    //richting opvangen
                    TxTID.Text = $" {naam}" + " - " + $"{richting} ";

                    SpRegistratie.IsEnabled = false;
                    TheGrid.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Je email is niet correct of je hebt geen naam ingegeven", "Ongeldige Input", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                MessageBox.Show("Je email is niet correct of je hebt geen naam ingegeven", "Ongeldige Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RadioButtons()
        {
            if (RbProgrameren.IsChecked == true)
            {
                richting = "PRO";
            }
            if (RbDigital.IsChecked == true)
            {
                richting = "DVO";
            }
            if (RbSysteem.IsChecked == true)
            {
                richting = "SNE";
            }
            else
                return;
        }

        private void RegistratieGroot(object sender, RoutedEventArgs e)
        {
            SpRegistratie.Width = 250;
        }

        private void RegistratieKlein(object sender, RoutedEventArgs e)
        {
            SpRegistratie.Width = 150;
        }

        private void ToonVogels(object sender, SelectionChangedEventArgs e)
        {

            //gekozenVogel = sender.SelectedIndex;


            if (sender == LbGespotteVogels)
            {
                gekozenVogel = LbGespotteVogels.SelectedIndex;
                CbTeSpottenVogels.SelectedValue = null;
            }
            else
            {
                gekozenVogel = CbTeSpottenVogels.SelectedIndex;
                LbGespotteVogels.SelectedValue = null;
            }
            LaadVogel(vogels[gekozenVogel ,0]);
        }

        private void LaadVogel(string vogel)
        {
            //afbeelding aanpassen
            Afbeelding.Source = new BitmapImage(new Uri($@"/Images/{vogels[gekozenVogel, 0]}.jpg", UriKind.Relative));

            //infoveld aanpassen
            StringBuilder sbInformatie = new StringBuilder();
            sbInformatie.AppendLine($"Naam: {vogels[gekozenVogel, 0]}");
            sbInformatie.AppendLine($"Familie: {vogels[gekozenVogel, 1]}");
            sbInformatie.AppendLine($"IUCN: {vogels[gekozenVogel, 2]}");
            string zeldzaamheid;
            sbInformatie.Append("Zeldzaamheid: ");
            for (int i = 0; i < Convert.ToInt32(vogels[gekozenVogel, 3]); i++)
            {
                sbInformatie.Append("V");
            }

            if (isVogelGespot.ContainsKey(vogels[gekozenVogel, 0]))
            {
                sbInformatie.AppendLine("\n" + "GESPOT");
                //CbGespot.IsEnabled = false;
            }
            else
            {
                //CbGespot.IsEnabled = true;
            }


            TxtInfo.Text = sbInformatie.ToString();

            //selectievakje aanpassen

        }

        private void CbGespot_Checked(object sender, RoutedEventArgs e)
        {

            ////if (vogels[gekozenVogel,0] == LbGespotteVogels.Items())
            ////if (isVogelGespot.ContainsKey(vogels[gekozenVogel, 0]) == false)
            //{
            //    //indien niet in dicto
            //    MessageBox.Show("nope");
            //    isVogelGespot.Add(vogels[gekozenVogel, 0], true);
            //    LbGespotteVogels.Items.Add(vogels[gekozenVogel, 0]);
            //    //CbGespot.IsChecked= false;


            //}

            //else
            //{

            //    //CbGespot.IsEnabled = true;
            //}





        }
    }


}

