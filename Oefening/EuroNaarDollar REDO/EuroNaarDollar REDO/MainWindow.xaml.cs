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

namespace REDO_Toepassing_1_Euro_omzetten_naar_Dollar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float euro;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                euro = Convert.ToSingle(txtEuro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            float uitkomst = euro * 1.03f;
            txtDollar.Text = uitkomst.ToString();



        }

        private void btnWissen_Click(object sender, RoutedEventArgs e)
        {
            txtDollar.Clear();
            txtEuro.Clear();

        }
    }
}
