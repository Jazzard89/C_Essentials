using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizza_Oefening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int AantalQStag;
        int AantalCapri;
        int AantalSal;
        int AantalPros;
        int AantalQuat;
        int AantalHaw;
        int AantalMar;
        string bestelling;
        string naamBesteller;
        string telBesteller;
        string mailBesteller;
        string adresBesteller;
        string woonplaatsBesteller;
        string postcodeBesteller;
        int extraMoz;
        int extraAns;
        int extraSal;
        int extraArt;
        float totaal;
        StringBuilder extras = new StringBuilder();
        List<CheckBox> cbList = new List<CheckBox>();
        List<string> stringList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            foreach(var child in stplExtras.Children)
            {
                cbList.Add((CheckBox)child);
            }
        }

        private void sldrQStag_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldrQStag = (Slider)sender;
            AantalQStag = Convert.ToInt32(sldrQStag.Value);
            txtInputQStag.Text = Convert.ToString(sldrQStag.Value);
        }

        private void sldrSal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldrSal = (Slider)sender;
            AantalSal = Convert.ToInt32(sldrSal.Value);
            txtInputSal.Text = Convert.ToString(sldrSal.Value);
        }

        private void sldrCapri_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldrCapri = (Slider)sender;
            AantalCapri = Convert.ToInt32(sldrCapri.Value);
            txtInputCapri.Text = Convert.ToString(sldrCapri.Value);
        }

        private void sldrPros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldrPros = (Slider)sender;
            AantalPros = Convert.ToInt32(sldrPros.Value);
            txtInputPros.Text = Convert.ToString(sldrPros.Value);
        }

        private void sldrQuat_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldrQuat = (Slider)sender;
            AantalQuat = Convert.ToInt32(sldrQuat.Value);
            txtInputQuat.Text = Convert.ToString(sldrQuat.Value);
        }

        private void sldrHaw_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldrHaw = (Slider)sender;
            AantalHaw = Convert.ToInt32(sldrHaw.Value);
            txtInputHaw.Text = Convert.ToString(sldrHaw.Value);
        }

        private void sldrMar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sldrMar = (Slider)sender;
            AantalMar = Convert.ToInt32(sldrMar.Value);
            txtInputMar.Text = Convert.ToString(sldrMar.Value);
        }














        private void btnPizza_Click(object sender, RoutedEventArgs e)
        {
            Button btnQStag = (Button)sender;

            switch (btnQStag.Name)
            {
                case "btnMnQStag":
                    //aantal word verminderd
                    AantalQStag--;
                    sldrQStag.Value = Convert.ToDouble(AantalQStag);
                    txtInputQStag.Text = Convert.ToString(AantalQStag);
                    //minimum & maximum input
                    if (AantalQStag < 0)
                    {
                        AantalQStag = 0;
                        txtInputQStag.Text = "0";
                    }
                    break;
                case "btnPlsQStag":
                    AantalQStag ++;
                    sldrQStag.Value = Convert.ToDouble(AantalQStag);
                    txtInputQStag.Text = Convert.ToString(AantalQStag);
                    if (AantalQStag > 15)
                    {
                        AantalQStag = 15;
                        txtInputQStag.Text = "15";
                    }
                    break;
                case "btnMnCapri":
                    //aantal word verminderd
                    AantalCapri--;
                    sldrCapri.Value = Convert.ToDouble(AantalCapri);
                    txtInputCapri.Text = Convert.ToString(AantalCapri);
                    //minimum & maximum input
                    if (AantalCapri < 0)
                    {
                        AantalCapri = 0;
                        txtInputCapri.Text = "0";
                    }
                    break;
                case "btnPlsCapri":
                    AantalCapri++;
                    sldrCapri.Value = Convert.ToDouble(AantalCapri);
                    txtInputCapri.Text = Convert.ToString(AantalCapri);
                    if (AantalCapri > 15)
                    {
                        AantalCapri = 15;
                        txtInputCapri.Text = "15";
                    }
                    break;

                case "btnMnSal":
                    //aantal word verminderd
                    AantalSal--;
                    sldrSal.Value = Convert.ToDouble(AantalSal);
                    txtInputSal.Text = Convert.ToString(AantalSal);
                    //minimum & maximum input
                    if (AantalSal < 0)
                    {
                        AantalSal = 0;
                        txtInputSal.Text = "0";
                    }
                    break;
                case "btnPlsSal":
                    //aantal word verminderd
                    AantalSal++;
                    sldrSal.Value = Convert.ToDouble(AantalSal);
                    txtInputSal.Text = Convert.ToString(AantalSal);
                    //minimum & maximum input
                    if (AantalSal > 15)
                    {
                        AantalSal = 15;
                        txtInputSal.Text = "15";
                    }
                    break;

                case "btnMnPros":
                    //aantal word verminderd
                    AantalPros--;
                    sldrPros.Value = Convert.ToDouble(AantalPros);
                    txtInputPros.Text = Convert.ToString(AantalPros);
                    //minimum & maximum input
                    if (AantalPros < 0)
                    {
                        AantalPros = 0;
                        txtInputPros.Text = "0";
                    }
                    break;
                case "btnPlsPros":
                    //aantal word verminderd
                    AantalPros++;
                    sldrPros.Value = Convert.ToDouble(AantalPros);
                    txtInputPros.Text = Convert.ToString(AantalPros);
                    //minimum & maximum input
                    if (AantalPros > 15)
                    {
                        AantalPros = 15;
                        txtInputPros.Text = "15";
                    }
                    break;

                case "btnMnQuat":
                    //aantal word verminderd
                    AantalQuat--;
                    sldrQuat.Value = Convert.ToDouble(AantalQuat);
                    txtInputQuat.Text = Convert.ToString(AantalQuat);
                    //minimum & maximum input
                    if (AantalQuat < 0)
                    {
                        AantalQuat = 0;
                        txtInputQuat.Text = "0";
                    }
                    break;
                case "btnPlsQuat":
                    //aantal word verminderd
                    AantalQuat++;
                    sldrQuat.Value = Convert.ToDouble(AantalQuat);
                    txtInputQuat.Text = Convert.ToString(AantalQuat);
                    //minimum & maximum input
                    if (AantalQuat > 15)
                    {
                        AantalQuat = 15;
                        txtInputQuat.Text = "15";
                    }
                    break;

                case "btnMnHaw":
                    //aantal word verminderd
                    AantalHaw--;
                    sldrHaw.Value = Convert.ToDouble(AantalHaw);
                    txtInputHaw.Text = Convert.ToString(AantalHaw);
                    //minimum & maximum input
                    if (AantalHaw < 0)
                    {
                        AantalHaw = 0;
                        txtInputHaw.Text = "0";
                    }
                    break;
                case "btnPlsHaw":
                    //aantal word verminderd
                    AantalHaw++;
                    sldrHaw.Value = Convert.ToDouble(AantalHaw);
                    txtInputHaw.Text = Convert.ToString(AantalHaw);
                    //minimum & maximum input
                    if (AantalHaw > 15)
                    {
                        AantalHaw = 15;
                        txtInputHaw.Text = "15";
                    }
                    break;

                case "btnMnMar":
                    //aantal word verminderd
                    AantalMar--;
                    sldrMar.Value = Convert.ToDouble(AantalMar);
                    txtInputMar.Text = Convert.ToString(AantalMar);
                    //minimum & maximum input
                    if (AantalMar < 0)
                    {
                        AantalMar = 0;
                        txtInputMar.Text = "0";
                    }
                    break;
                case "btnPlsMar":
                    //aantal word verminderd
                    AantalMar++;
                    sldrMar.Value = Convert.ToDouble(AantalMar);
                    txtInputMar.Text = Convert.ToString(AantalMar);
                    //minimum & maximum input
                    if (AantalMar > 15)
                    {
                        AantalMar = 15;
                        txtInputMar.Text = "15";
                    }
                    break;







                default:
                    return;
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

            //if (chkMoz.IsChecked == true)
            //{
            //    extraMoz = 1;
            //    totaal = totaal + 0.5f;
            //}
            //if (chkMoz.IsChecked == false)
            //{
            //    extraMoz = 0;
            //}
            //if (chkAns.IsChecked == true)
            //{
            //    extraAns = 1;
            //    totaal = totaal + 0.5f;
            //}
            //if (chkAns.IsChecked == false)
            //{
            //    extraAns = 0;
            //}
            //if (chkArt.IsChecked == true)
            //{
            //    extraArt = 1;
            //    totaal = totaal + 0.5f;
            //}
            //if (chkArt.IsChecked == false)
            //{
            //    extraArt = 0;
            //}
            //if (chkSal.IsChecked == true)
            //{
            //    extraSal = 1;
            //    totaal = totaal + 0.5f;
            //}
            //if (chkSal.IsChecked == false)
            //{
            //    extraSal = 0;
            //}
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
                $" {AantalQStag} Pizza Quatro Stagioni (€12,5)" + "\n" +
                $" {AantalCapri} Pizza Capricciosa (€13,0)" + "\n" +
                $" {AantalSal} Pizza Salami Al Fuoco (€12,0)" + "\n" +
                $" {AantalPros} Pizza Prosciutto (€11,0)" + "\n" +
                $" {AantalQuat} Pizza Quattro Formaggi (€12,5)" + "\n" +
                $" {AantalHaw} Pizza Hawai (€12,0)" + "\n" +
                $" {AantalMar} Pizza Margeherita (€9,0)" + "\n";
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