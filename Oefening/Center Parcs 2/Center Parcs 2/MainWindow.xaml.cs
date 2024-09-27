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

namespace Center_Parcs_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] aantalDagen = new int[] { 1, 2, 5, 7, 8, 12, 14, 21 };
        private string[,] woningMetPrijs = new string[5, 2] {
                                {"2 personen", "80" },
                                { "4 personen", "120" },
                                { "4 personen lux", "140" },
                                { "6 personen", "180" },
                                { "8 personen", "200" } };
        int uitkomst;



        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < aantalDagen.Length; i++)
            {
                aantalDagen[i] = cbAantalDagen.Items.Add(aantalDagen[i]);
            }

            int aantalRijen = woningMetPrijs.GetLength(0);



            for (int r = 0; r < aantalRijen; r++)
            {
                //dit is fout    
                //woningMetPrijs[r, 0] = Convert.ToString(cbTypeWoning.Items.Add(woningMetPrijs[r, 0]));
                cbTypeWoning.Items.Add(woningMetPrijs[r, 0]);

            }



        }



        //combox content aantal personen = array content, prijs = array content(2) x aantal dagen array


        private void cbTypeWoning_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            //ook fout
            if ((cbTypeWoning.SelectedItem != null) && (cbAantalDagen.SelectedIndex != -1))
            {
                int selectieWoning = cbTypeWoning.SelectedIndex;

                int prijsWoning = Convert.ToInt32(woningMetPrijs[selectieWoning, 1]);

                int selectieDagen = int.Parse(cbAantalDagen.SelectedValue.ToString());

                //int gezochteIndex = IndexVanWoningType(cbTypeWoning.SelectedValue.ToString());
                //int prijsWoning = Convert.ToInt32(woningMetPrijs[gezochteIndex, 1]);


                uitkomst = prijsWoning * selectieDagen;
                txtPrijs.Text = $"{uitkomst:c}";
            }

            else
            {

            }
        }


        //Met Array
        //private int IndexVanWoningType(string omschrijving)
        /*{
            for (int i = 0; i < woningMetPrijs.GetLength(0); i++)
            {
                if (omschrijving == woningMetPrijs[i, 0])
                {
                    return i;
                }
            }
            return -1;
        }
        */


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Array.Sort(aantalDagen);
        }
    }
}
