using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary

    public partial class MainWindow : Window
    {
        float getal1;
        float getal2;
        float resultaat;


        public MainWindow()
        {
            InitializeComponent();
            //Focus leggen op textblok
            TxtGetal1.Focus();
        }


        private void LeesGetallen(string getaltekst1, string getaltekst2)
        {
            //de text word uitgelezen in het text veld wanneer de method word uitgevoert. ze staan er langs.
            getal1 = float.Parse(getaltekst1);
            getal2 = float.Parse(getaltekst2);
        }





        private void Bewerking(object sender, RoutedEventArgs e)
        {
            LeesGetallen(TxtGetal1.Text, TxtGetal2.Text);

            Button btn = (Button)sender;
            //we maken hier een Button vaiable aan die btn heet, en we gebruiken de inhoud van de eventclicker ()
            //dus indien we op de + klikken is de + de (button)sender en gaat + ook naar de switch case

            //switch (((Button)sender).Name)
            switch (btn.Name)
            {
                case "BtnPlus":
                    resultaat = Berekenen('+');
                    break;
                case "BtnMin":
                    resultaat = Berekenen('-');
                    break;
                case "BtnMaal":
                    resultaat = Berekenen('*');
                    break;
                case "BtnDelen":
                    resultaat = Berekenen('/');
                    break;
                default:
                    return;
            }



            TxtResultaat.Text = resultaat.ToString();
            TxtGetal1.Focus();


        }

        private float Berekenen(char teken)
        {
            switch (teken)
            {
                case '+':
                    return getal1 + getal2;
                case '-':
                    return getal1 - getal2;
                case '*':
                    return getal1 * getal2;
                case '/':
                    return getal1 / getal2;
                default:
                    return 0.0f;
            }
        }


        private void WissenBtn_Click(object sender, RoutedEventArgs e)

        //Read only van maken
        {
            TxtResultaat.Clear();
            TxtGetal1.Clear();
            TxtGetal2.Text = "";
            TxtGetal1.Focus();
        }

    }
}


