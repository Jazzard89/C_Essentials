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
        private DispatcherTimer klok = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            klok.Tick += TimerEvent;
            klok.Interval = new TimeSpan(0, 0, 8);
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if (Rood.Visibility == Visibility)
            {
                Rood.Visibility = Visibility.Hidden;
                Groen.Visibility = Visibility.Visible;
                klok.Interval = new TimeSpan(0, 0, 0, 4);

            }

            else if (Groen.Visibility == Visibility)
            {
                Groen.Visibility = Visibility.Hidden;
                Oranje.Visibility = Visibility.Visible;
                klok.Interval = new TimeSpan(0, 0, 0, 2);
            }

            else if (Oranje.Visibility == Visibility)
            {
                Oranje.Visibility = Visibility.Hidden;
                Rood.Visibility = Visibility.Visible;
                klok.Interval = new TimeSpan(0, 0, 0, 8);
            }
        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            klok.Start();
        }
    }
}
