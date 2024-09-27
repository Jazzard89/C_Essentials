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
using static System.Net.Mime.MediaTypeNames;

namespace Examen_oefeningen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private DispatcherTimer klok = new DispatcherTimer();

        private List<string> namen = new List<string>() { "Sander", "Quirino", "Thomas",
    "Cédric", "Jason", "Domenico", "Rickert", "Klaas", "Tom", "Stephan", "Alexander",
    "Yannick", "Robin", "Dave", "Lynn", "Arno", "Niels", "Maxiem", "Matthijs", "Kobe",
    "Michaël", "Bram", "Achraf", "Raf", "Sven", "Gerben", "Kevin", "Cem", "Steff", "Steven",
    "Rani", "Djordy", "Nick", "Mikail", "Konstantin", "Asad", "Viktor", "Antonio", "Senne",
    "Benjamin", "Stef", "Abdul", "Christiaan", "Abdurrahman", "Jurgen", "Kevin", "Silvio",
    "Nathan", "Stijn", "Bart", "Frank", "Steven", "Matty", "Arend", "Simon", "Ziggy",
    "Pascal", "Michaël", "Danny", "Robby", "Johan", "Vincent", "Wim", "Tuba", "Kristof",
    "Kenneth" };
        TextBox[] prognoseVakken = new TextBox[6];
        private string[,] lidgeldPerCat = { { "Preminiem", "150" }, { "Miniem", "150" }, {
    "Junior", "170" }, { "Kadet", "170" },{ "Senior", "200" } };
        StringBuilder sbResultaat = new StringBuilder();
        int inschrijvingsgeld;
        int totaal;
        int korting;
        int rang;




        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, EventArgs e)
        {

            //bij iedere tick voer de event uit
            klok.Tick += new EventHandler(klokAfgelopen);
            //de klok zet een nieuwe interval op 1 seconde
            klok.Interval = new TimeSpan(0, 0, 1);
            //start de klok
            klok.Start();
            //toon eerste tijd direct, inplaats van na 1 seconde
            KlokToon();

            //zet string namen in de combobox
            foreach (string naam in namen) { cbNaam.Items.Add(naam); }

            //initialiseren
            int i = 0;
            foreach (var item in StackPanelPrognose.Children)
            {
                if (item is TextBox == true)
                {
                    prognoseVakken[i] = (TextBox)item;
                    i++;
                }
            }
        }


        private void klokAfgelopen(object sender, EventArgs e)
        {
            KlokToon();
        }

        private void KlokToon()
        {
            //schrijf tijd text uit
            txtTimeShow.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
        }


        private void Wissen(object sender, RoutedEventArgs e)
        {
            //herstart alle waardes naar standaard waardes
            cbCompetitielid.IsChecked = false;
            cbNieuwLid.IsChecked = false;
            txtRang.Clear();
            txtTijd.Clear();
            rbCad.IsChecked = true;

            spPrognose.Visibility = Visibility.Hidden;

            inschrijvingsgeld = 0;
            txtResultaat.Text = string.Empty;
            cbNaam.SelectedIndex = -1;
            sbResultaat.Clear();
        }

        private void Afsluiten(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Berekenen(object sender, RoutedEventArgs e)
        {
            float breedte = 420;
            totaal = 0;
            korting = 0;

            //competitieleden betalen €50 extra
            if (cbCompetitielid.IsChecked == true)
            {
                totaal += 50;
            }






            Single.TryParse(txtTijd.Text, out float tijd);
            float verbetering = (tijd / 100) * 5;
            float verbeteringBreedte = (breedte / 100) * 5;


            if (cbNieuwLid.IsChecked == true)
            {
                spPrognose.Visibility = Visibility.Visible;
                foreach (TextBox tb in prognoseVakken)
                {
                    tb.Width = breedte;
                    tb.Text = Convert.ToString(tijd);
                    tijd -= verbetering;
                    breedte -= verbeteringBreedte;
                }
            }







            //indien de radiobutton Prem is gechecked tel 150euro erbij
            if (rbPrem.IsChecked == true)
            {
                //inschrijvingsgeld += lidgeldPerCat.GetValue(1);
                inschrijvingsgeld = Convert.ToInt32(lidgeldPerCat[0, 1]);

            }

            //indien de radiobutton Min is gechecked tel 150euro erbij
            if (rbMin.IsChecked == true)
            {
                //inschrijvingsgeld += lidgeldPerCat.GetValue(1);
                inschrijvingsgeld = Convert.ToInt32(lidgeldPerCat[1, 1]);
            }

            //indien de radiobutton Jun is gechecked tel 150euro erbij
            if (rbJun.IsChecked == true)
            {
                //inschrijvingsgeld += lidgeldPerCat.GetValue(1);
                inschrijvingsgeld = Convert.ToInt32(lidgeldPerCat[2, 1]);
            }

            //indien de radiobutton Cad is gechecked tel 150euro erbij
            if (rbCad.IsChecked == true)
            {
                //inschrijvingsgeld += lidgeldPerCat.GetValue(1);
                inschrijvingsgeld = Convert.ToInt32(lidgeldPerCat[3, 1]);
            }

            //indien de radiobutton Sen is gechecked tel 150euro erbij
            if (rbSen.IsChecked == true)
            {
                //inschrijvingsgeld += lidgeldPerCat.GetValue(1);
                inschrijvingsgeld = Convert.ToInt32(lidgeldPerCat[4, 1]);
            }

            totaal += inschrijvingsgeld;

            try
            {
                rang = Convert.ToInt32(txtRang.Text);



                switch (rang)
                {
                    case 1:
                        break;

                    case 2:
                        korting = 5;
                        break;

                    case 3:
                        korting = 10;
                        break;

                    case 4:
                        korting = 15;
                        break;

                    case 5:
                        korting = 20;
                        break;

                    case 6:
                        korting = 25;
                        break;

                    default: break;
                }


                if (korting >= 5)
                {
                    //200 / 100 * 5 = 10
                    //200 - 10
                    totaal = totaal - (totaal / 100) * korting;
                }


                sbResultaat.AppendLine($"Inschrijvingsbedrag voor {cbNaam.SelectedValue} \n \n" +
                    $"Basisbedrag voor {cbNaam.SelectedValue}: {inschrijvingsgeld} \n" +
                    $"Te betalen {totaal} ");



                txtResultaat.Text = sbResultaat.ToString();
            }
            catch
            {
                MessageBox.Show("foute input");
                txtRang.Clear();
                totaal = 0;
            }
        }
    }
}
