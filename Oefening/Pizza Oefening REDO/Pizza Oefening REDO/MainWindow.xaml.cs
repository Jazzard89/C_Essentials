using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace Pizza_Oefening_REDO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string bestelling;
        string naamBesteller;
        string telBesteller;
        string mailBesteller;
        string adresBesteller;
        string woonplaatsBesteller;
        string postcodeBesteller;
        float totaal;
        StringBuilder extras = new StringBuilder();
        List<CheckBox> cbList = new List<CheckBox>();
        List<string> stringList = new List<string>();
        List<Slider> sliderList = new List<Slider>();
        List<TextBox> textBoxList = new List<TextBox>();

        //7 rijen en 2 collomen
        Button[] buttonArray = new Button[14];



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var child in stplExtras.Children)
            {
                cbList.Add((CheckBox)child);
            }

            foreach (var child in spSelectie.Children)
            {
                if (child is Slider)
                {
                    sliderList.Add((Slider)child);
                }
            }





            for (int i = 0; i < buttonArray.GetLength(0); i++)
            {
                    foreach (var child in spSelectie.Children)
                    {
                        if (child is DockPanel dp)
                        {
                            foreach (var granchild in dp.Children)
                            {
                                if (granchild is Button)
                                {
                                    buttonArray[i] = (Button)granchild;
                                }
                            }
                        }
                    }
            }
            



            foreach (var child in spSelectie.Children)
            {
                if (child is DockPanel dockpanel)
                {
                    foreach (var dockChild in dockpanel.Children)
                    {
                        if (dockChild is Slider)
                        {
                            sliderList.Add((Slider)dockChild);
                        }
                    }
                }
            }

            foreach (var child in spSelectie.Children)
            {
                if (child is DockPanel dockpanel)
                {
                    foreach (var dockChild in dockpanel.Children)
                    {
                        if (dockChild is TextBox)
                        {
                            textBoxList.Add((TextBox)dockChild);
                        }
                    }
                }
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            int rij = sliderList.IndexOf(slider);
            textBoxList[rij].Text = Convert.ToString(slider.Value);
        }


        private void btnPizza_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;


            for (int i = 0; i < buttonArray.Length; i++)
            {
                //MessageBox.Show($"{buttonArray[i, 0].Name}");
                //MessageBox.Show($"{(Button)sender}");

                if (buttonArray[i] == clickedButton)
                {
                    int aantal;

                    if (i % 2 == 0)
                    {
                        // i is an even number
                        MessageBox.Show("aftrekken");

                        aantal = Convert.ToInt32(textBoxList[i]);
                        aantal -= 1;
                        textBoxList[i].Text = Convert.ToString(aantal);
                        if (aantal < 0)
                        {
                            aantal = 0;
                            textBoxList[i].Text = "0";
                        }
                    }

                    else
                    {
                        // i is an uneven number

                        MessageBox.Show("optellen");

                        aantal = Convert.ToInt32(textBoxList[i]);
                        aantal += 1;
                        textBoxList[i].Text = Convert.ToString(aantal);
                        if (aantal > 15)
                        {
                            aantal = 15;
                            textBoxList[i].Text = "15";
                        }
                    }
                }
            }
        }

        private void tik_Checked(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox cb in cbList)
            {
                if (cb.IsChecked == true)
                {
                    stringList.Add($"1x {cb.Content}");
                    totaal += 0.5f;
                }
            }
        }

        private void btnBestel_Click(object sender, RoutedEventArgs e)
        {
            totaal = (AantalQStag * 12.5f) + (AantalCapri * 13) + (AantalSal * 12)
                + (AantalPros * 11) + (AantalQuat * 12.5f) + (AantalHaw * 12) + (AantalMar * 9);

            naamBesteller = Convert.ToString(txtNaam.Text);
            telBesteller = Convert.ToString(txtTel.Text);
            mailBesteller = Convert.ToString(txtEmail.Text);
            adresBesteller = Convert.ToString(txtAdres.Text);
            woonplaatsBesteller = Convert.ToString(txtWoonplaats.Text);
            postcodeBesteller = Convert.ToString(txtPostcode.Text);
            bestelling = $"Naam: {naamBesteller}" + "\r" + $"Telefoonnummer: {telBesteller}"
                + "\n" + $"Mail: {mailBesteller}" + "\n" + $"Adres: {adresBesteller}"
                + "\n" + $"Woonplaats: {woonplaatsBesteller}" + $" {postcodeBesteller}" + "\n" + "\n"
                + "u heeft de volgende bestelling gemaakt" + "\n" +
                "-----------------------------------------------" + "\n" +
                $"  Pizza Quatro Stagioni (€12,5)" + "\n" +
                $"  Pizza Capricciosa (€13,0)" + "\n" +
                $"  Pizza Salami Al Fuoco (€12,0)" + "\n" +
                $"  Pizza Prosciutto (€11,0)" + "\n" +
                $"  Pizza Quattro Formaggi (€12,5)" + "\n" +
                $"  Pizza Hawai (€12,0)" + "\n" +
                $"  Pizza Margeherita (€9,0)" + "\n";
            //$" {extraMoz} Extra Mozarella (€0,5)" + "\n" + $" {extraArt} Extra Artisjok (€0,5)" + "\n" +
            //$" {extraSal} Extra Salami (€0,5)" + "\n" + $" {extraAns} Extra Ansjovis (€0,5)" + "\n" +

            foreach (var item in stringList)
            {
                bestelling += item + "\n";
            }
            bestelling += $" Totaal: {totaal}";

            txtBestelling.Text = Convert.ToString(bestelling);
        }
    }
}

