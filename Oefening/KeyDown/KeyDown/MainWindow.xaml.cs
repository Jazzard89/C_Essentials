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

namespace KeyDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int nummerEen;
        int nummerTwee;
        int resultaat;



        public MainWindow()
        {
            InitializeComponent();
        }


        private void txtNummer2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Add)
            {
                CheckNumbers();
                resultaat = nummerEen + nummerTwee;
            }

            if (e.Key == Key.Subtract)
            {
                CheckNumbers();
                resultaat = nummerEen - nummerTwee;
            }

            txtresultaat.Text = Convert.ToString(resultaat);
        }


        //verwijder het getypte teken
        private void txtNummer_TextChanged(object sender, EventArgs e)
        {
            txtNummer2.Text = new
                string(txtNummer2.Text.Where(char.IsDigit).ToArray());

            txtNummer1.Text = new
                string(txtNummer1.Text.Where(char.IsDigit).ToArray());
        }




        //controleer dat de invoer een nummer is
        private void CheckNumbers()
        {
            if (int.TryParse(txtNummer1.Text, out nummerEen))
            {
                nummerEen = Convert.ToInt32(txtNummer1.Text);
            }
            else
            {
                MessageBox.Show("invalid input");
            }

            if (int.TryParse(txtNummer2.Text, out nummerTwee))
            {
                nummerTwee = Convert.ToInt32(txtNummer2.Text);
            }
            else
            {
                MessageBox.Show("invalid input");
            }
        }





    }
}
