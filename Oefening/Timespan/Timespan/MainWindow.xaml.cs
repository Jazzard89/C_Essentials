using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Timespan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer klok = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            //telkens als timer aflopt word event uitgevoert
            //klok.Tick += klokAfgelope
            klok.Tick += new EventHandler(klokAfgelopen); // Event koppelen
            klok.Interval = new TimeSpan(0, 0, 1); //Elke seconde
            //na het bovenstaande word de dispatcher uitgevoert
            //Test git mag weg
        }
        private void klokAfgelopen(object sender, EventArgs e)
        {
            LblTijd.Content = $"{DateTime.Now.ToLongTimeString()}";
            lblEen.Visibility = (lblEen.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible);
            lblTwee.Visibility = (lblTwee.Visibility == Visibility.Visible ? Visibility.Hidden  : Visibility.Visible);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            klok.Start(); // Timer start
            //na het bovenstaande start de timer pas
        }
    }
}
