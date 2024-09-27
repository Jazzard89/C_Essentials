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

namespace Verkeerslicht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //declaratie van de timer (globaal)
        private DispatcherTimer TijdRood = new DispatcherTimer();
        private DispatcherTimer TijdOranje = new DispatcherTimer();
        private DispatcherTimer TijdGroen = new DispatcherTimer();




        public MainWindow()
        {
            InitializeComponent();
            TijdRood.Tick += TimerVoorRood;
            TijdOranje.Tick += TimerVoorOranje;
            TijdGroen.Tick += TimerVoorGroen;
            TijdRood.Interval = new TimeSpan(0, 0, 0, 8);
            TijdOranje.Interval = new TimeSpan(0, 0, 0, 2);
            TijdGroen.Interval = new TimeSpan(0, 0, 0, 4);
        }

        //voor image toe te voegen, klik op project in het rechtsevenster met rechtermuisknop, add, excisting item
        //zet filter op all files



        private void TimerVoorRood (object sender, EventArgs e)
        //aanmaken van event
        {
            // == wilt zeggen boolean het eindigd met het ? antwoord 1 : antwoord 2
            Rood.Visibility = Visibility.Hidden;
            Oranje.Visibility = Visibility.Hidden;
            Groen.Visibility = Visibility.Visible;

            TijdGroen.Start();
            TijdRood.Stop();
        }

        private void TimerVoorOranje(object sender, EventArgs e)
        {
            Rood.Visibility = Visibility.Visible;
            Oranje.Visibility = Visibility.Hidden;
            Groen.Visibility= Visibility.Hidden;

            TijdRood.Start();
            TijdOranje.Stop();
        }

        private void TimerVoorGroen(object sender, EventArgs e)
        {
            Rood.Visibility = Visibility.Hidden;
            Oranje.Visibility = Visibility.Visible;
            Groen.Visibility = Visibility.Hidden;

            TijdOranje.Start();
            TijdGroen.Stop();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //oranje en groen moeten invisible worden en timer van rood moet starten
            Rood.Visibility = Visibility.Visible;
            Oranje.Visibility = Visibility.Hidden;
            Groen.Visibility = Visibility.Hidden;

            TijdRood.Start();
        }
    }
}
