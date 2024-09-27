using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace Menus
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

        private void Menu_Click(object ssndr, RoutedEventArgs e)
        {
            // mijn object sender is het volgende)
            //Menu item = (MenuItm)seender:
            //MessageBox.Show(item.Header.ToString());

            MessageBox.Show(((MenuItem)sender).Header(ToString);


            Color.FromRgb;
            //ischecked in xaml leer dit


        }
        private void Schuifregelaar_ValueChanged(object sender, RoutedPropertyChangedEventArgs e)
        {
            lblWaarde.Content = Schuifregelaar.Value;
        }
    }
}
