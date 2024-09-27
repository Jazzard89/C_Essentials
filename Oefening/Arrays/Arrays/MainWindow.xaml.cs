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
using System.Xml.Linq;

namespace Arrays


    //artemis axel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] preIntArray = new int[10] { 51, 92, 3, 14, 5, 62, 77, 28, 9, 120 };
        double[] preDoubleArray = new double[10] {52, 5.3, 12, 5, 41, 51, 10, 5, 6, 71 };
        int[] legeIntArray = new int[10];
        string[] preStringArray = new string[10] { "woord", "stoel", "TV", "ontbijt", "gordel", "koffie", "hond", "ijzer", "sneeuw", "kamer" };
        string[] legeStringArray = new string[10];
        float[] preFloatArray = new float[10];
        float[,] pre2DArray = { { 21, 8.2f }, { 1.3f, 1.4f }, { 8.1f, 2.3f }, { 5, 22 } };
        float[,] lege2DArray = new float[4, 2];
        int i = 0;

        public MainWindow()
        {
            InitializeComponent();

            //koppel selected items uit cbArrays aan arrays
            cbArrays.Items.Add("preIntArray");
            cbArrays.Items.Add("legeIntArray");
            cbArrays.Items.Add("preStringArray");
            cbArrays.Items.Add("legeStringArray");
            cbArrays.Items.Add("pre2DArray");
            cbArrays.Items.Add("lege2DArray");


        }



        private void Go(object sender, RoutedEventArgs e)
        {
            switch (cbWatDoen.SelectedIndex)
            {
                ////////////////////////////////////////////////////////
                case 0: //uitlezen
                    switch (cbArrays.SelectedItem)
                    {
                        case "preIntArray":
                            UitlezenInt(preIntArray);
                            break;

                        case "legeIntArray":
                            UitlezenInt(legeIntArray);
                            break;

                        case "preStringArray":
                            UitlezenString(preStringArray);
                            break;

                        case "legeStringArray":
                            UitlezenString(legeStringArray);
                            break;

                        case "pre2DArray":
                            Uitlezen2D(pre2DArray);
                            break;

                        case "lege2DArray":
                            Uitlezen2D(lege2DArray);
                            break;
                    }
                    break;



                ////////////////////////////////////////////////////////
                case 1: //toevoegen

                    switch (cbArrays.SelectedItem)
                    {
                        case "preIntArray":
                            ToevoegenInt(preIntArray);
                            break;

                        case "legeIntArray":
                            ToevoegenInt(legeIntArray);
                            break;

                        case "preStringArray":
                            ToevoegenString(preStringArray);
                            break;

                        case "legeStringArray":
                            ToevoegenString(legeStringArray);
                            break;

                        case "pre2DArray":
                            Toevoegen2D(pre2DArray);
                            break;

                        case "lege2DArray":
                            Toevoegen2D(lege2DArray);
                            break;
                    }
                    break;



                ////////////////////////////////////////////////////////
                case 2: //verwijderen
                    switch (cbArrays.SelectedItem)
                    {
                        case "preIntArray":
                            VerwijderenInt(preIntArray);
                            break;

                        case "legeIntArray":
                            VerwijderenInt(legeIntArray);
                            break;

                        case "preStringArray":
                            VerwijderenString(preStringArray);
                            break;

                        case "legeStringArray":
                            VerwijderenString(legeStringArray);
                            break;

                        case "pre2DArray":
                            Verwijderen2D(pre2DArray);
                            break;

                        case "lege2DArray":
                            Verwijderen2D(lege2DArray);
                            break;
                    }
                    break;



                ////////////////////////////////////////////////////////
                case 3: //leeg maken
                    switch (cbArrays.SelectedItem)
                    {
                        case "preIntArray":
                            MaakLeeg(preIntArray);
                            break;

                        case "legeIntArray":
                            MaakLeeg(legeIntArray);
                            break;

                        case "preStringArray":
                            MaakLeeg(preStringArray);
                            break;

                        case "legeStringArray":
                            MaakLeeg(legeStringArray);
                            break;

                        case "pre2DArray":
                            MaakLeeg2D(pre2DArray);
                            break;

                        case "lege2DArray":
                            MaakLeeg2D(lege2DArray);
                            break;
                    }
                    break;

            }
        }


        void UitlezenInt(int[] sender)
        {
            lbResult.Items.Clear();
            if (cbSort.IsChecked == true)
            {
                Array.Sort(sender);
                if (cbReverse.IsChecked == true)
                {
                    Array.Reverse(sender);
                }
            }
            foreach (int var in sender)
            {
                if (var != 0)
                {
                    lbResult.Items.Add(var);
                }
            }
        }

        void UitlezenString(string[] sender)
        {
            lbResult.Items.Clear();
            if (cbSort.IsChecked == true)
            {
                Array.Sort(sender);
                if (cbReverse.IsChecked == true)
                {
                    Array.Reverse(sender);
                }

            }
            foreach (object var in sender)
            {
                if (var != null)
                {
                    lbResult.Items.Add(var);
                }
            }
        }

        void Uitlezen2D(float[,] sender)
        {
            lbResult.Items.Clear();
            lbResult2.Items.Clear();
            if (cbSort.IsChecked == true)
            {
                //rows zijn 0, colums zijn 1
                //dit zijn de rows
                for (int k = 0; k < sender.GetLength(0); k++)
                {
                    for (int p = 0; p < sender.GetLength(0); p++)
                    {
                        if (sender[k, 0] < sender[p, 0])
                        {
                            float grootste = sender[p, 0];
                            float kleinste = sender[k, 0];
                            sender[k, 0] = grootste;
                            sender[p, 0] = kleinste;
                        }
                        else
                        {
                            float kleinste = sender[p, 0];
                            float grootste = sender[k, 0];
                            sender[k, 0] = grootste;
                            sender[p, 0] = kleinste;
                        }
                    }
                }

                for (int k = 0; k < sender.GetLength(0); k++)
                {
                    for (int p = 0; p < sender.GetLength(0); p++)
                    {
                        if (sender[k, 1] < sender[p, 1])
                        {
                            float grootste = sender[p, 1];
                            float kleinste = sender[k, 1];
                            //MessageBox.Show($"kleiner {kleinste}");
                            //MessageBox.Show($"grooter {grootste}");
                            sender[k, 1] = grootste;
                            sender[p, 1] = kleinste;
                        }
                        else
                        {
                            float kleinste = sender[p, 1];
                            float grootste = sender[k, 1];
                            //MessageBox.Show($"kleiner {kleinste}");
                            //MessageBox.Show($"grooter {grootste}");
                            sender[k, 1] = grootste;
                            sender[p, 1] = kleinste;
                        }
                    }
                }
            }
            if (cbReverse.IsChecked == true)
            {

                //rows zijn 0, colums zijn 1
                //dit zijn de eerste posities
                for (int k = 0; k < sender.GetLength(0); k++)
                {
                    for (int p = 0; p < sender.GetLength(0); p++)
                    {
                        if (sender[k, 0] < sender[p, 0])
                        {
                            float kleinste = sender[p, 0];
                            float grootste = sender[k, 0];
                            sender[k, 0] = grootste;
                            sender[p, 0] = kleinste;
                        }
                        else
                        {
                            float grootste = sender[p, 0];
                            float kleinste = sender[k, 0];
                            sender[k, 0] = grootste;
                            sender[p, 0] = kleinste;
                        }
                    }
                }

                //rows zijn 0, colums zijn 1
                //dit zijn de tweede posities
                for (int k = 0; k < sender.GetLength(0); k++)
                {
                    for (int p = 0; p < sender.GetLength(0); p++)
                    {
                        if (sender[k, 1] < sender[p, 1])
                        {
                            float kleinste = sender[p, 1];
                            float grootste = sender[k, 1];
                            sender[k, 1] = grootste;
                            sender[p, 1] = kleinste;
                        }
                        else
                        {
                            float grootste = sender[p, 1];
                            float kleinste = sender[k, 1];
                            sender[k, 1] = grootste;
                            sender[p, 1] = kleinste;
                        }
                    }
                }
            }
            if (cb2DArray.IsChecked == true)
            {
                //schrijf het resultaat van eerste colom
                for (int k = 0; k < sender.GetLength(0); k++)
                {
                    if (sender[k, 0] != 0)
                    {
                        lbResult.Items.Add(sender[k, 0]);
                    }
                }

                //schrijf het resultaat van tweede colom
                for (int k = 0; k < sender.GetLength(0); k++)
                {
                    if (sender[k, 1] != 0)
                    {
                        lbResult2.Items.Add(sender[k, 1]);
                    }
                }
            }
            else
            {
                //uitschrijven resultaat
                for (int k = 0; k < sender.GetLength(0); k++)
                {
                    for (int j = 0; j < sender.GetLength(1); j++)
                    {
                        if (sender[k, j] != 0)
                        {
                            lbResult.Items.Add(sender[k, j]);
                        }
                    }
                }
            }
        }

        void ToevoegenInt(int[] sender)
        {
            //((add this global ' int i = 0; ' // 
            //(sender[9] is max length of array
            if (sender[sender.Length - 1] != 0)
                MessageBox.Show("Array is vol");
            else
            {
                while (sender[i] != 0)
                {
                    i++;
                }
                try { sender[i] = Convert.ToInt32(txtItem.Text); }
                catch { MessageBox.Show("foute input"); }

                i = 0;
            }
        }

        void ToevoegenString(string[] sender)
        {
            if (sender[9] != null)
                MessageBox.Show("Array is vol");
            else
            {
                while (sender[i] != null)
                {
                    i++;
                }
                try { sender[i] = Convert.ToString(txtItem.Text); }
                catch { MessageBox.Show("foute input"); }

                i = 0;
                lbResult.Items.Clear();
                UitlezenString(sender);
            }
        }

        void Toevoegen2D(float[,] sender) 
        {
            lbResult.Items.Clear();
            lbResult2.Items.Clear();
            if (cb2DArray.IsChecked == true)
            {
                if ((txtItem.Text != "") && (txtItem2.Text != ""))
                {
                    MessageBox.Show("only one input please");
                }

                if ((txtItem.Text == "") && (txtItem2.Text == ""))
                {
                    MessageBox.Show("provide input please");
                }

                else
                {
                    if (txtItem.Text != "")
                    {
                        if (sender[3, 0] != 0)
                        {
                            MessageBox.Show("Array is vol");
                            Uitlezen2D(sender);
                        }

                        //indien iets word toegevoegd op [4,0] word nieuwe collom aangemaakt

                        else
                        {
                            for (int k = 0; k < sender.GetLength(0); k++)
                            {
                                if (sender[k, 0] == 0)
                                {
                                    sender[k, 0] = Convert.ToSingle(txtItem.Text);
                                    Uitlezen2D(sender);
                                    txtItem.Clear();
                                    txtItem2.Clear();
                                    return;
                                }
                            }
                        }
                    }

                    if (txtItem2.Text != "")
                    {
                        if (sender[3, 1] != 0)
                            MessageBox.Show("Array is vol");
                        //indien iets word toegevoegd op [4,0] word nieuwe collom aangemaakt

                        else
                        {
                            for (int k = 0; k < sender.GetLength(0); k++)
                            {
                                if (sender[k, 1] == 0)
                                {
                                    sender[k, 1] = Convert.ToSingle(txtItem2.Text);
                                    Uitlezen2D(sender);
                                    txtItem.Clear();
                                    txtItem2.Clear();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            if (cb2DArray.IsChecked == false)
            {
                if (sender[3, 1] != 0)
                    MessageBox.Show("Array is vol");
                //indien iets word toegevoegd op [4,0] word nieuwe collom aangemaakt

                else
                {
                    for (int k = 0; k < sender.GetLength(0); k++)
                    {
                        for (int j = 0; j < sender.GetLength(1); j++)
                        {
                            if (sender[k, j] == 0)
                            {
                                sender[k, j] = Convert.ToSingle(txtItem.Text);
                                lbResult.Items.Clear();
                                lbResult2.Items.Clear();
                                Uitlezen2D(sender);
                                return;
                            }
                        }
                    }
                }
            }
        }

        void VerwijderenInt(int[] sender)
        {
            //selected item van listbox wissen uit array
            if (sender.Contains(Convert.ToInt32(lbResult.SelectedItem)))
            {
                for (int i = 0; i < sender.Length; i++)
                {
                    if (sender[i] == (int)lbResult.SelectedItem)
                    {
                        sender[i] = 0;
                        for (int j = i + 1; j < sender.Length; j++)
                        {
                            sender[j - 1] = sender[j];
                            sender[sender.Length - 1] = 0;
                        }
                    }
                }
                lbResult.Items.Clear();
                UitlezenInt(sender);
            }
            else
            {
                return;
            }
            return;
        }

        void VerwijderenString(string[] sender)
        {
            if (sender.Contains(Convert.ToString(lbResult.SelectedItem)))
            {
                for (int i = 0; i < sender.Length; i++)
                {
                    if (sender[i] == (string)lbResult.SelectedItem)
                    {
                        sender[i] = null;
                        for (int j = i + 1; j < sender.Length; j++)
                        {
                            sender[j - 1] = sender[j];
                            sender[9] = null;
                        }
                    }
                }
                lbResult.Items.Clear();
                UitlezenString(sender);
            }
            else
                return;
        }

        void Verwijderen2D(float[,] sender)
        {   if (cb2DArray.IsChecked == false)
            {
                for (int i = 0; i < sender.GetLength(0); i++)
                {
                    for (int j = 0; j < sender.GetLength(1); j++)
                    {
                        if (sender[i, j] == Convert.ToSingle(lbResult.SelectedItem))
                        {
                            sender[i, j] = default(float);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < sender.GetLength(0); i++)
                {
                    if (sender[i,0] == Convert.ToSingle(lbResult.SelectedItem))
                    {
                        sender[i, 0] = default(float);
                    }
                }

                for (int i = 0; i < sender.GetLength(0); i++)
                {
                    if (sender[i, 1] == Convert.ToSingle(lbResult2.SelectedItem))
                    {
                        sender[i, 1] = default(float);
                    }
                }
            }

            Uitlezen2D(sender);
        }

        void MaakLeeg<T>(T[] sender)
        {
                //Array Leegmaken
                Array.Clear(sender, 0, sender.Length);
                lbResult.Items.Clear();
        }

        void MaakLeeg2D(float [,] sender)
        {
            //2D Array Leegmaken
            for (int i = 0; i < sender.GetLength(0); i++)
            {
                for (int j = 0; j < sender.GetLength(1); j++)
                {
                    sender[i, j] = default;
                }
            }
        }




        void Toevoegen<T>(T[] sender)
        {
            if (sender[9] != null)
                MessageBox.Show("Array is vol");
            else
            {
                while (sender[i] != null)
                {
                    i++;
                }
                try
                {
                    T item = (T)Convert.ChangeType(txtItem.Text, typeof(T));
                    sender[i] = item;
                }
                catch { MessageBox.Show("foute input"); }

                i = 0;
                lbResult.Items.Clear();
                Uitlezen(sender);
            }
        }

        void Uitlezen<T>(T[] sender)
        {
            lbResult.Items.Clear();
            if (cbSort.IsChecked == true)
            {
                Array.Sort(sender);
                if (cbReverse.IsChecked == true)
                {
                    Array.Reverse(sender);
                }
            }
            foreach (T var in sender)
            {
                if (!var.Equals(default(T)))
                {
                    lbResult.Items.Add(var);
                }
                else
                    return;
            }
        }






        private void Clear(object sender, RoutedEventArgs e)
        {
            lbResult.Items.Clear();
            lbResult2.Items.Clear();
        }

        private void cbArrays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbArrays.SelectedIndex == 4) || (cbArrays.SelectedIndex == 5))
            {
                cb2DArray.Visibility = Visibility.Visible;
            }
            else
            {
                cb2DArray.Visibility = Visibility.Hidden;
            }

            lbResult2.Items.Clear();
            lbResult.Items.Clear();
        }

        private void cb2DArray_Checked(object sender, RoutedEventArgs e)
        {
            if (cb2DArray.IsChecked == true)
            {
                lbResult.Items.Clear();
                lbResult2.Items.Clear();

                lbResult.Width = lbResult.Width = 170;
                lbResult.HorizontalAlignment = HorizontalAlignment.Left;
                lbResult2.Visibility = Visibility.Visible;

                txtItem.Width = txtItem.Width = 165;
                txtItem2.Visibility = Visibility.Visible;
            }

            if (cb2DArray.IsChecked == false)
            {
                lbResult.Items.Clear();
                lbResult2.Items.Clear();

                //display op orde zetten
                lbResult.Width = lbResult.Width = 340;
                lbResult.HorizontalAlignment = HorizontalAlignment.Center;
                lbResult2.Visibility = Visibility.Hidden;

                txtItem.Width = txtItem.Width = 340;
                txtItem2.Visibility = Visibility.Hidden;
            }
        }

        private void cbSort_Checked(object sender, RoutedEventArgs e)
        {
            if (cbSort.IsChecked == true)
            {
                cbReverse.Visibility = Visibility.Visible;
            }
            if (cbSort.IsChecked == false)
            {
                cbReverse.Visibility = Visibility.Hidden;
            }

        }

        private void cbWatDoen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
