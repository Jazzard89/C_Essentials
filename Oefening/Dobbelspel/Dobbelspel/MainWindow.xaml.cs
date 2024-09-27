using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dobbelspel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int winRood;
        int winGroen;
        string getallenGroen = "";
        string getallenRood = "";
        string winnaar;
        string winnaarTotaal;
        int finalClick = 0;





        public MainWindow()
        {
            InitializeComponent();
            txtDateTime.Text = DateTime.Now.ToString();
        }



        private void RB_Checked(object sender, RoutedEventArgs e)
        {
            //selecteer spel (5)
            if (btnVijf.IsChecked == true)
            {
                lblSelector.Content = $"Eerste van vijf wint!";
                btnDobbelen.IsEnabled = true;
                btnVijf.IsEnabled = false;
                btnTien.IsEnabled = false;
                btnVijftien.IsEnabled = false;
                Title = $"Eerste van vijf wint!";
            }

            //selecteer spel (10)
            else if (btnTien.IsChecked == true) 
            {
                lblSelector.Content = $"Eerste van tien wint!";
                btnDobbelen.IsEnabled = true;
                btnVijf.IsEnabled = false;
                btnTien.IsEnabled = false;
                btnVijftien.IsEnabled = false;
                Title = $"Eerste van tien wint!";
            }

            //selecteer spel (15)
            else if (btnVijftien.IsChecked == true)
            {
                lblSelector.Content = $"Eerste van vijftien wint!";
                btnDobbelen.IsEnabled = true;
                btnVijf.IsEnabled = false;
                btnTien.IsEnabled = false;
                btnVijftien.IsEnabled = false;
                Title = $"Eerste van vijftien wint!";
            }
        }




        private void btnDobbelen_Click(object sender, RoutedEventArgs e)
        {
            if (winnaarTotaal == null)
            {

                //aanmaken 2 random getalen
                Random rnd = new Random();
                int getal1 = rnd.Next(1, 6);
                int getal2 = rnd.Next(1, 6);



                //wie heeft het hoogste getal (groen)
                if (getal1 > getal2)
                {
                    winnaar = "Groen";

                    //teller
                    winGroen = winGroen + 1;
                    string groenWint = ($" {winGroen} Keer gewonnen");
                    txtGroenResultaat.Text = groenWint;

                    //winnaar singel spel
                    middenVeld1.Text = "Jij wint!";
                    middenVeld1.Background = Brushes.Green;

                    //image
                    jijWint.Visibility = Visibility.Visible;
                    vuistImage.Visibility = Visibility.Hidden;
                    computerWint.Visibility = Visibility.Hidden;
                }


                //wie heeft het hoogste getal (rood)
                else if (getal1 < getal2)
                {
                    winnaar = "Rood";

                    //teller
                    winRood = winRood + 1;
                    string roodWint = ($" {winRood} Keer gewonnen");
                    txtRoodResultaat.Text = roodWint;

                    //winnaar singel spel
                    middenVeld1.Text = "Computer wint!";
                    middenVeld1.Background = Brushes.Red;

                    //image
                    jijWint.Visibility = Visibility.Hidden;
                    vuistImage.Visibility = Visibility.Hidden;
                    computerWint.Visibility = Visibility.Visible;
                }


                //wie heeft het hoogste getal (gelijk)
                else if (getal1 == getal2)
                {
                    winnaar = "Gelijk";

                    //winnaar singel spel
                    middenVeld1.Text = "Gelijkspel!";
                    middenVeld1.Background = Brushes.Blue;

                    //image
                    vuistImage.Visibility = Visibility.Visible;
                    jijWint.Visibility = Visibility.Hidden;
                    computerWint.Visibility = Visibility.Hidden;
                }


                //getal toevoegen aan string (global definition)
                getallenGroen = getallenGroen + "\n" + getal1;
                getallenRood = getallenRood + "\n" + getal2;
                txtGroen.Text = getallenGroen;
                txtRood.Text = getallenRood;



                //aantal games gespeeld
                if (btnVijf.IsChecked == true && (winGroen == 5 || winRood == 5))
                {
                    DataWissen();
                }
                if (btnTien.IsChecked == true && (winGroen == 10 || winRood == 10))
                {
                    DataWissen();
                }
                if (btnVijftien.IsChecked == true && (winGroen == 15 || winRood == 15))
                {
                    DataWissen();
                }
            }





            ////////////////////////////////////
            if (winnaarTotaal != null)
            {

                btnDobbelen.Content = "Eindresultaat";

                if (finalClick == 1)
                    { 
                    //messagesbox
                    MessageBox.Show($"De winnaar is {winnaarTotaal} ");

                    //knoppen naar default
                    btnDobbelen.IsEnabled = false;
                    btnVijf.IsEnabled = true;
                    btnTien.IsEnabled = true;
                    btnVijftien.IsEnabled = true;

                    //textveld leegmaken
                    txtGroenResultaat.Text = null;
                    txtRoodResultaat.Text = null;
                    txtGroen.Text = null;
                    txtRood.Text = null;
                    btnVijf.IsChecked = false;
                    btnTien.IsChecked = false;
                    btnVijftien.IsChecked = false;
                    getallenGroen = null;
                    getallenRood = null;
                    btnDobbelen.Content = "Dobbelen";
                    winGroen = 0;
                    winRood = 0;
                    winnaar = null;
                    winnaarTotaal = null;
                    }

                else
                    {
                    finalClick = finalClick + 1;
                    }

                    

            }   



        }
        private void DataWissen ()
        {


            //klik op knop voor resultaat ((moet nog ingevoert worden))
            //Opgelet: 1 knop met 1 click event (hierbinnen opvangen met (Button)sender)-
            //Bij klik op “Eindscore” wordt messagebox getoond met de winnaar-



            //Winnaar verklaren
            if (winGroen > winRood)
                {
                winnaarTotaal = "Groen";
                }
            else if (winGroen < winRood)
                {
                winnaarTotaal = "Rood";
                }






            //winnaar resultaat tonen
            if (winnaar == "Rood")
                {
                //image
                vuistImage.Visibility = Visibility.Hidden;
                jijWint.Visibility = Visibility.Hidden;
                computerWint.Visibility = Visibility.Visible;
                }

            if (winnaar == "Groen")
                {
                //image
                vuistImage.Visibility = Visibility.Hidden;
                jijWint.Visibility = Visibility.Visible;
                computerWint.Visibility = Visibility.Hidden;
                }
        }
    }
}
