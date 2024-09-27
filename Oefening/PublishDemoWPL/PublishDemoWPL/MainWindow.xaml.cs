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

namespace PublishDemoWPL
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




        // duw 3x op ' / ' om dit menu hieronder op te roepen, dit geeft een hover effect over de parameters om uitleg te geven.



        /// <summary>
        /// Deze methode gaat een complex nulpunt bereen van de zeta fuctie.
        /// <para>
        /// opsomming
        /// </para>
        /// </summary>
        /// <param name="zeta"></param>
        /// <returns>
        /// dit is de uitkomst van de berekening
        /// </returns>


        private string DoComplexStuff(double zeta)
        {
            // To do stuff

            return "Complex antwoord";
        }
    }
}
