using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace Reaction_Speed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DateTime klok = DateTime.Now;
        StringBuilder score = new StringBuilder();
        Random rnd = new Random();
        private DispatcherTimer klok = new DispatcherTimer();
        private DispatcherTimer timer = new DispatcherTimer();
        private DispatcherTimer reactionTimer = new DispatcherTimer();
        bool clicker = true;
        string naam;
        int pictureSelector;
        int reactionStopWatch;
        TimeSpan reactionStopWatchDateTime;
        bool messaged;


        public MainWindow()
        {
            InitializeComponent();
            klok.Start();
            klok.Interval = new TimeSpan(0, 0, 1);
            klok.Tick += KlokEvent;

            txtNaam.Focus();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            naam = txtNaam.Text;

            if (naam == "")
            {
                MessageBox.Show("voer een naam in");
                txtNaam.Focus();
            }

            if (naam != "")
            {
                if (clicker == true)
                {
                    if (messaged == false)
                    {
                        MessageBox.Show("When you see the monster. \n click on it as fast as you can!");
                        messaged = true;
                    }

                    reactionStopWatch = 0;
                    timer.Start();
                    timer.Tick += TimerEvent;
                    timer.Interval = new TimeSpan(0, 0, 1);
                    btnStart.Content = "Click";
                    imPicture.Visibility = Visibility.Visible;
                }


                if ((clicker == false) && (pictureSelector == 1))
                {
                    timer.Stop();

                    score.AppendLine(Convert.ToString($"{reactionStopWatchDateTime} - {naam}"));
                    txtSnelsteTijd.Text = score.ToString();

                    imPicture.Visibility = Visibility.Hidden;

                    btnStart.Content = "Start";
                    clicker = true;
                }
            }
        }

        private void KlokEvent(object sender, EventArgs e)
        {
            lblTijd.Content = DateTime.Now.ToShortTimeString();
        }

            private void TimerEvent(object sender, EventArgs e)
        {
            pictureSelector = rnd.Next(1, 5);
            imPicture.Source = new BitmapImage(new Uri($@"{pictureSelector}.jpg", UriKind.Relative));
            timer.Interval = new TimeSpan(0, 0, 1);


            if (pictureSelector == 1)
            {
                reactionTimer.Start();
                reactionTimer.Tick += ReactionTimerEvent;
                reactionTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            }
            else if (pictureSelector != 1)
            {
                reactionTimer.Stop();
            }



            clicker = false;
        }

        private void ReactionTimerEvent(object sender, EventArgs e)
        {

            reactionTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            reactionStopWatch++;
            reactionStopWatchDateTime = new TimeSpan (0, 0, 0, 0, reactionStopWatch);
        }



        /*1. Als de speler op de startknop drukt, dan wordt er iedere seconden eenwillekeurige afbeelding geladen.
         * 2. Als het monster wordt geladen, dan wordt er een timer gestart die dereactiesnelheid van de speler meet.
         * 3. Als de speler op het monster klikt, dan wordt de reactie timer gestopten eindigt het spel.
         * 4. Als de speler op een afbeelding klikt dat niet het monster is, dan krijgtde speler een strafpunt. */

        /* Afloop spel:
        * 1. Als het spel eindigt, dan wordt de speler geïnformeerd van zijn of haarreactiesnelheid en aantal strafpunten.
        * 2. Als de speler een nieuwe hoogste score heeft behaald, dan wordt despeler hiermee geïnformeerd met behulp van een dialoogvenster.
        * 3. Als de speler een nieuwe hoogste score heeft behaald, dan wordt denaam van de speler gevraagd.
        * 4. Als de speler een nieuwe hoogste score heeft behaald, dan wordt denaam van de speler getoond met zijn of haar reactiesnelheid. */


    }
} 
