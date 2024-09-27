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

namespace FrmDelenTryCatch
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

        private void btnBerekenen_Click(object sender, RoutedEventArgs e)
        {
            /*De opdrachtknop btnBereken.
             * Bij het klikken op deze knop wordt de waarde uit txtDeeltal door
             * txtDeler gedeeld en het resultaat getoond in txtQuotient.
             * Als er fouten optreden, danverschijnt een gepaste melding
             * zoals in volgende schermvoorbeelden wordt getoond:*/
            try 
            { 
            int Deeltal = Convert.ToInt32(txtDeeltal.Text);
            int Deler = Convert.ToInt32(txtDeler.Text);
            }


            //de ex is de variabele, deze word dan getoont in de message
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (StackOverflowException)
            {

            }


            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }



            



        }
    }
}
