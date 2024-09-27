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

namespace Oefening_29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int berekening;

        public MainWindow()
        {
            InitializeComponent();
            
        }


        //methode 1
        public void ToonInkomen (int jaarSal, int aantalJaren)
        {
            //TxtTotaal.Text = Convert.ToString(jaarSal * aantalJaren); dit is methode 2
            berekening = jaarSal * aantalJaren;
        }

        //methode 2
        //public int ToonInkomen (int a, int b)          (bij deze is een return value)


        private void BtnToonInkomen_Click(object sender, RoutedEventArgs e)
        {
            bool isGelukt = Int32.TryParse(TxtJaarsal.Text, out int jaarSalaris);
            bool isGelukt2 = Int32.TryParse(TxtAantaljaren.Text, out int aantalJaren);
            if (isGelukt == false || isGelukt2 == false)
            {
                //messagebox
                MessageBoxResult antwoord = MessageBox.Show("foute invoer", "fout ontdekt", MessageBoxButton.OKCancel);
                if (antwoord == MessageBoxResult.Cancel)
                    Close();
            }



            else
            {
                ToonInkomen(jaarSalaris, aantalJaren);
                // methode 1
                TxtTotaal.Text = $"{berekening:c}";

                //methode 2
                //blanco
            }
        }
    }
}
