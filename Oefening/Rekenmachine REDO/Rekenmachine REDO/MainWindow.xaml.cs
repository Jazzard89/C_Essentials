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

namespace Rekenmachine_REDO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float getal1;
        float getal2;
        float uitkomst;


        public MainWindow()
        {
            InitializeComponent();
            txtGetal1.Focus();
        }




        //de strings zijn strings omdat ze een text veld mee krijgen wanneer ze worden uitgevoerd en text is string
        private void LeesGetallen(string getal1text, string getal2text)
        {
            try
            {
                getal1 = Convert.ToSingle(getal1text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                getal2 = Convert.ToSingle(getal2text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWissen_Click(object sender, RoutedEventArgs e)
        {
            txtGetal1.Clear();
            txtGetal2.Clear();
            txtResultaat.Clear();
            getal1 = 0;
            getal2 = 0;
            uitkomst = 0;
        }

        private void btnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            //aanmaken nieuwe button = (Object van hierboven is een (button)sender
            Button btn = (Button)sender;

            //De methode word uitgevoerd met de textvelden
            LeesGetallen(txtGetal1.Text, txtGetal2.Text);

            switch (btn.Name)
            {
                case "btnPlus":
                    uitkomst = Berekenen('+');
                    break;
                case "btnMin":
                    uitkomst = Berekenen('-');
                    break;
                case "btnMaal":
                    uitkomst = Berekenen('x');
                    break;
                case "btnDeel":
                    uitkomst = Berekenen('/');
                    break;
            }

            txtResultaat.Text = Convert.ToString(uitkomst);
        }


        private float Berekenen(char teken)
        {
            switch (teken)
            {
                case '+':
                    return getal1 + getal2;
                case '-':
                    return getal1 - getal2;
                case 'x':
                    return getal1 * getal2;
                case '/':
                    return getal1 / getal2;
                default:
                    return 0.0f;
            }
        }





    }
}
