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

namespace Woordenboek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> Woordenboek = new Dictionary<string, string>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVoegToe_Click(object sender, RoutedEventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(txtWoord.Text)) ;
            {
                txtWoord.Background = Brushes.Red;
            }
            else
            {
                txtWoord.Background = Brushes.White;
            }

            if (string.IsNullOrWhiteSpace(txtUitleg.Text)) ;
            {
                txtUitleg.Background = Brushes.Red;
            }
            else
            {
                txtUitleg.Background = Brushes.White;
            }*/

            txtWoord.Background = string.IsNullOrWhiteSpace(txtWoord.Text) ? Brushes.Red: Brushes.White;
            txtUitleg.Background = string.IsNullOrWhiteSpace(txtUitleg.Text) ? Brushes.Red : Brushes.White;


            if (!string.IsNullOrWhiteSpace(txtWoord.Text) && !string.IsNullOrWhiteSpace(txtUitleg.Text))
            {


                //if(Woordenboek.ContainsKey(txtWoord.Text) == false)
                if (Woordenboek.ContainsKey(txtWoord.Text))
                {
                    MessageBoxResult antwoord = MessageBox.Show("Wilt u dit overschrijven?", "Woord bestaat al!", MessageBoxButton.YesNo);
                    if (antwoord == MessageBoxResult.Yes)
                    {
                        //selectie op min 1 zetten om gebruiker te verplichten iets aan te duiden
                        lsbxLijst.SelectedIndex = -1;
                        Woordenboek[txtWoord.Text] = txtUitleg.Text;
                    }
                    
                }
                else
                {
                    Woordenboek.Add(txtWoord.Text, txtUitleg.Text);
                    lsbxLijst.Items.Add(txtWoord.Text);
                }
            }            
        }

        private void lsbxLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtUitleg2.Clear();
            if (lsbxLijst.SelectedIndex != -1)
            {
                txtUitleg2.Text = Woordenboek[lsbxLijst.SelectedValue.ToString()];
            }
            
        }
    }
}
