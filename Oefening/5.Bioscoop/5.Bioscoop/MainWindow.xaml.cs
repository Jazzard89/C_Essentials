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

namespace _5.Bioscoop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variabelen aanmaken
        float normaalAantal;
        float kortingAantal;
        float studentAantal;



        public MainWindow()
        {
           InitializeComponent();

            //Focus leggen
            TxtNormaal.Focus();
        }
        //comment
        private void BtnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            //uitlezen
            normaalAantal = Convert.ToSingle(TxtNormaal.Text);
            kortingAantal = Convert.ToSingle(TxtKorting.Text);
            studentAantal = Convert.ToSingle(TxtStudent.Text);
            //berekenen norm 9.10, korting 8.10, stud 6.9
            double teBetalen = (normaalAantal * 9.10) + (kortingAantal * 8.10) + (studentAantal * 6.9);
            //schrijven
            TxtTeBetalen.Text = Convert.ToString(teBetalen);
            //Enter toets
            


        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            TxtKorting.Clear();
            TxtNormaal.Clear();
            TxtStudent.Clear();
            TxtTeBetalen.Clear();
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
