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

namespace messagebox
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

        private void btnTheButton_Click(object sender, RoutedEventArgs e)
        {

            //Standaard knop
            MessageBox.Show("Geef getal", "Titel ", MessageBoxButton.YesNoCancel , MessageBoxImage.Question, MessageBoxResult.Yes);


            // Resultaatwaarden
            MessageBoxResult antw = MessageBox.Show("Wil je echt afsluiten?", "Project afsluiten.",
            MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (antw == MessageBoxResult.Yes)
            {
                Close();
            }
            else
            { // Cancel het Closing-event en windows wordt niet gesloten.
                stckThis.Background = Brushes.Red;
            }
        }
    }
}
