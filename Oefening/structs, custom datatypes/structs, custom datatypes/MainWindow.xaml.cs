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

namespace Structs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i;

        //struct declaratie
        struct Cars
        {
            public string Brand;
            public string Model;
            public int Year;
            public float Price;
        }

        //array declaratie
        Cars[] carArray = new Cars[10];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Cars car1;
            car1.Brand = txtBrand.Text;
            car1.Model = txtModel.Text;
            car1.Year = Convert.ToInt32(txtYear.Text);
            car1.Price = Convert.ToSingle(txtPrice.Text);

            //plaats bovenstaande in array
            carArray[i] = car1;


            //////plaats in listbox en schrijf deze
            ////foreach (Cars ev in carArray)
            ////{
            ////    lbResultaat.Items.Add($"{ev.Brand} - {ev.Model}: {ev.Year}: {ev.Price}");
            ////}

            lbResultaat.Items.Add($"--{carArray[i].Brand}-- \n {carArray[i].Model} \n {carArray[i].Year} \n  {carArray[i].Price}");

            //verhoog positie in array
            i++;

            //wis alle vorige input
            txtBrand.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            txtYear.Clear();
        }

        private void btnArray_Click(object sender, RoutedEventArgs e)
        {
            int getal = Convert.ToInt32(txtArray.Text);
            MessageBox.Show($"{carArray[getal].Brand} \n {carArray[getal].Model} \n {carArray[getal].Year} \n  {carArray[getal].Price}");
        }

        private void txtArray_GotFocus(object sender, EventArgs e)
        {
            txtArray.Clear();
        }
    }
}
