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

namespace euroOmzettenNaarDollar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtEuro_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            //Euro omzetten naar dollar
            //1euro = 0.98 dollar

            //Stap 1: euro uitlezen
            float euroBedrag = Convert.ToSingle(TxtEuro.Text);
            //Stap 2: berkening maken
            //float dollarbedrag = euroBedrag * Convert.ToSingle(0.98);
            float dollarBedrag = euroBedrag * 0.98f;
            //Stap 3: berekening tonen
            TxtDollar.Text = Convert.ToString(dollarBedrag);
        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            //Textvakken leegmaken
            TxtEuro.Text = "";
            TxtDollar.Clear();
        }
    }
}
