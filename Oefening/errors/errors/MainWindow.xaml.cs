using System;
using System.Collections.Generic;
using System.Data;
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

namespace errors
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


        private void BtnTestDebug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isGelukt = int.TryParse(tbGetal1.Text, out int deeltal);

                int deler = Convert.ToInt32(tbGetal2.Text);
                double quotient = Berekenen(deeltal, deler);
                string quotienText = quotient.ToString();
                lblInfo.Content = quotienText;
            }

            //volgorde van specifiek naar generiek
            catch(DivideByZeroException)
            {
                MessageBox.Show("U mag niet door 0 delen");
            }
            catch(FormatException)
            {
                MessageBox.Show("Fout formaat");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int Berekenen(int getal1, int getal2)
        {
            return getal1 / getal2;
        }
    }
}
