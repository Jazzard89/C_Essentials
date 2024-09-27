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

namespace Cirkelberkening
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
        //Delete knop
        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            //verwijderen
            oppTxt.Text = " ";
            omtrekTxt.Text = " ";
            straalTxt.Text = " ";
        }

        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            float straalInCm = Convert.ToSingle(straalTxt.Text);
            //berekening maken
            float oppInCm = (straalInCm * straalInCm) * 3.14f;
            float omtrekInCm = (straalInCm * 2) *3.14f;
            //berkening tonen
            oppTxt.Text = Convert.ToString(oppInCm);
            omtrekTxt.Text = Convert.ToString(omtrekInCm);
        }

        private void straalTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
