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

namespace _7.Reiskost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //varbs instellen
        float vluchtPrijs;
        float aantalDagen;
        float prijsDag;
        float aantalPersonen;
        float resultaten;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            TxtAantalDagen.Clear();
            TxtAantalPersonen.Clear();
            TxtBasisDagprijs.Clear();
            TxtBasisvluchtprijs.Clear();
            TxtBestemming.Clear();
            TxtKortingsPercentage.Clear();
            TxtVluchtklasse.Clear();
        }

        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            vluchtPrijs = Convert.ToSingle(TxtBasisvluchtprijs.Text);
            aantalDagen = Convert.ToSingle(TxtAantalDagen.Text);
            prijsDag = Convert.ToSingle(TxtBasisDagprijs.Text);
            aantalPersonen = Convert.ToSingle(TxtAantalPersonen.Text);
            //berekenen
            resultaten = (vluchtPrijs + (prijsDag * aantalDagen)) * aantalPersonen;
            //schrijven
            TxtResultaten.Text = resultaten.ToString();
        }
    }
}
