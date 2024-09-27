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

namespace examenTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string topic;
        string subject;
        string datatype;
        string converterSender;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbTopic_change(object sender, SelectionChangedEventArgs e)
        {
            cbSubject.Visibility = Visibility.Visible;
            lblSubject.Visibility = Visibility.Visible;

            if (cbTopic.SelectedIndex == 0)
            {
                cbSubject.Items.Clear();
                cbSubject.Items.Add("Int [] Array");
                cbSubject.Items.Add("Int [,] Array");
                cbSubject.Items.Add("double [] Array");
                cbSubject.Items.Add("double [,] Array");
                cbSubject.Items.Add("float [] Array");
                cbSubject.Items.Add("float [,] Array");
                cbSubject.Items.Add("string [] Array");
                cbSubject.Items.Add("string [,] Array");
                cbSubject.Items.Add("custom datatype [] Array");
                cbSubject.Items.Add("custom datatype [,] Array");

                cbFunction.Items.Clear();
                cbFunction.Items.Add("declaration");
                cbFunction.Items.Add("Toevoegen aan Array");
                cbFunction.Items.Add("Uitlezen van Array");
                cbFunction.Items.Add("Sorteren van Array");
                cbFunction.Items.Add("Verwijderen van Array item");
                cbFunction.Items.Add("Verwijderen van Array");
            }

            if (cbTopic.SelectedIndex == 1)
            {
                cbSubject.Items.Clear();
                cbSubject.Items.Add("List<int>");
                cbSubject.Items.Add("List<double>");
                cbSubject.Items.Add("List<float>");
                cbSubject.Items.Add("List<string>");
                cbSubject.Items.Add("List<custom datatype>");
                cbSubject.Items.Add("List<custom datatype>");

                cbFunction.Items.Clear();
                cbFunction.Items.Add("declaration");
                cbFunction.Items.Add("initialization");
                cbFunction.Items.Add("Toevoegen aan Lists");
            }

            if (cbTopic.SelectedIndex == 2)
            {
                cbSubject.Items.Clear();
                cbSubject.Items.Add("voeg een lange Tijd toe");
                cbSubject.Items.Add("voeg een lange dattm toe");
                cbSubject.Items.Add("breng wijziging toe na bepaalde tijd");

                cbFunction.Items.Clear();
                cbFunction.Items.Add("declaration");
                cbFunction.Items.Add("initialization");
            }
        }

        private void cbSubject_change(object sender, SelectionChangedEventArgs e)
        {
            lblFunction.Visibility = Visibility.Visible;
            cbFunction.Visibility = Visibility.Visible;
            lboxResult.Items.Clear();
        }

        private void cbFunction_change(object sender, SelectionChangedEventArgs e)
        {
            //hier komen alle resultaten
            ///////////////////////////////////int
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 0) & (cbFunction.SelectedIndex == 0))
            {
                datatype = "int";
                Declaration("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 0) & (cbFunction.SelectedIndex == 1))
            {
                datatype = "int";
                Toevoegen("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 0) & (cbFunction.SelectedIndex == 2))
            {
                Read("int");   
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 0) & (cbFunction.SelectedIndex == 3))
            {
                Sort();
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 0) & (cbFunction.SelectedIndex == 4))
            {
                Delete("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 0) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArray();
            }





            ///////////////////////////////////int[,]
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 1) & (cbFunction.SelectedIndex == 0))
            {
                datatype = "int";
                DeclarationD("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 1) & (cbFunction.SelectedIndex == 1))
            {
                datatype = "int";
                ToevoegenD("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 1) & (cbFunction.SelectedIndex == 2))
            {
                ReadD("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 1) & (cbFunction.SelectedIndex == 3))
            {
                SortD("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 1) & (cbFunction.SelectedIndex == 4))
            {
                DeleteD("int");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 1) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArrayD();
            }




            ///////////////////////////////////doubles
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 2) && (cbFunction.SelectedIndex == 0))
            {
                datatype = "double";
                Declaration("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 2) & (cbFunction.SelectedIndex == 1))
            {
                datatype = "double";
                Toevoegen("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 2) & (cbFunction.SelectedIndex == 2))
            {
                Read("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 2) & (cbFunction.SelectedIndex == 3))
            {
                Sort();
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 2) & (cbFunction.SelectedIndex == 4))
            {
                Delete("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 2) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArray();
            }


            ///////////////////////////////////double[,]
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 3) & (cbFunction.SelectedIndex == 0))
            {
                datatype = "double";
                DeclarationD("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 3) & (cbFunction.SelectedIndex == 1))
            {
                datatype = "double";
                ToevoegenD("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 3) & (cbFunction.SelectedIndex == 2))
            {
                ReadD("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 3) & (cbFunction.SelectedIndex == 3))
            {
                SortD("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 3) & (cbFunction.SelectedIndex == 4))
            {
                DeleteD("double");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 3) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArrayD();
            }

            ///////////////////////////////////float
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 4) && (cbFunction.SelectedIndex == 0))
            {
                datatype = "float";
                Declaration("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 4) && (cbFunction.SelectedIndex == 1))
            {
                datatype= "float";
                Toevoegen("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 4) && (cbFunction.SelectedIndex == 2))
            {
                Read("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 4) && (cbFunction.SelectedIndex == 3))
            {
                Sort();
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 4) & (cbFunction.SelectedIndex == 4))
            {
                Delete("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 4) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArray();
            }


            ///////////////////////////////////float[,]
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 5) & (cbFunction.SelectedIndex == 0))
            {
                datatype = "float";
                DeclarationD("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 5) & (cbFunction.SelectedIndex == 1))
            {
                datatype = "float";
                ToevoegenD("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 5) & (cbFunction.SelectedIndex == 2))
            {
                ReadD("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 5) & (cbFunction.SelectedIndex == 3))
            {
                SortD("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 5) & (cbFunction.SelectedIndex == 4))
            {
                DeleteD("float");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 5) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArrayD();
            }


            ///////////////////////////////////string
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 6) && (cbFunction.SelectedIndex == 0))
            {
                datatype = "string";
                Declaration("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 6) && (cbFunction.SelectedIndex == 1))
            {
                datatype = "string";
                Toevoegen("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 6) && (cbFunction.SelectedIndex == 2))
            {
                Read("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 6) && (cbFunction.SelectedIndex == 3))
            {
                Sort();
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 6) & (cbFunction.SelectedIndex == 4))
            {
                Delete("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 6) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArray();
            }



            ///////////////////////////////////string[,]
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 7) & (cbFunction.SelectedIndex == 0))
            {
                datatype = "string";
                DeclarationD("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 7) & (cbFunction.SelectedIndex == 1))
            {
                datatype = "string";
                ToevoegenD("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 7) & (cbFunction.SelectedIndex == 2))
            {
                ReadD("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 7) & (cbFunction.SelectedIndex == 3))
            {
                SortD("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 7) & (cbFunction.SelectedIndex == 4))
            {
                DeleteD("string");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 7) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArrayD();
            }


            ///////////////////////////////////custom /////////////////////////////////////////////////////////
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 8) && (cbFunction.SelectedIndex == 0))
            {
                datatype = "custom";
                Declaration("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 8) && (cbFunction.SelectedIndex == 1))
            {
                datatype = "custom";
                Toevoegen("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 8) && (cbFunction.SelectedIndex == 2))
            {
                Read("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 8) && (cbFunction.SelectedIndex == 3))
            {
                Sort();
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 8) & (cbFunction.SelectedIndex == 4))
            {
                Delete("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 8) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArray();
            }



            ///////////////////////////////////string[,]
            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 9) & (cbFunction.SelectedIndex == 0))
            {
                datatype = "custom";
                DeclarationD("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 9) & (cbFunction.SelectedIndex == 1))
            {
                datatype = "custom";
                ToevoegenD("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 9) & (cbFunction.SelectedIndex == 2))
            {
                ReadD("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 9) & (cbFunction.SelectedIndex == 3))
            {
                SortD("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 9) & (cbFunction.SelectedIndex == 4))
            {
                DeleteD("custom");
            }

            if ((cbTopic.SelectedIndex == 0) & (cbSubject.SelectedIndex == 9) & (cbFunction.SelectedIndex == 5))
            {
                EmptyArrayD();
            }
        }









        private void lboxResult_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(lboxResult.SelectedItem) == "")
            {
                return;
            }
            else
            {
                Clipboard.SetText(lboxResult.SelectedItem.ToString());
            }
        }










        private void Declaration(object sender)
        {
            lboxResult.Items.Clear();
            if (datatype == "string")
            {
                lboxResult.Items.Add($"string[] nameArray = new string[10] {{ \"woord\", \"tafel\", \"brood\", \"radio\", \"koffie\", \"hamster\", \"woonkamer\", \"bessen\", \"taart\", \"woonkamer\" }};");
            }
            else
            {
                lboxResult.Items.Add($"{sender}[] nameArray = new {sender}[10]" + "{ 51, 92, 3, 14, 5, 62, 77, 28, 9, 120 };");
            }
            lboxResult.Items.Add($"{sender}[] nameArray = new {sender}[10];");
            lboxResult.Items.Add($"{sender}[] preIntArray = new {sender}[]" + "{ };");
        }

        private void DeclarationD(object sender)
        {
            lboxResult.Items.Clear();
            if (datatype == "string")
            {
                lboxResult.Items.Add($"{sender}[,] nameArray = {{ {{ \"braadworst\", \"appelsien\" }}, {{ \"augurk\", \"wijn\" }}, {{ \"volvo\", \"been\" }}, {{ \"ziekenhuis\", \"drama\" }} }};");
            }
            else
            {
                lboxResult.Items.Add($"{sender}[,] nameArray = {{ {{ 21, 8 }}, {{ 1, 1 }}, {{ 8, 2 }}, {{ 5, 22 }} }};");
            }
            lboxResult.Items.Add($"{sender}[,] nameArray = new {sender}[4, 2];");
        }

        private void Toevoegen(object sender)
        {
            lboxResult.Items.Clear();
            if (datatype == "int")
                converterSender = "Int32";

            if (datatype == "double")
                converterSender = "Double";

            if (datatype == "float")
                converterSender = "Single";

            if (datatype != "string")
            {
                converterSender = "String";
            }

            lboxResult.Items.Add("//Add an item from textbox \r \n //((add this global ' int i = 0; ' // \r\n if (sender[sender.Length - 1] != 0) || (sender[sender.Length - 1] != null)\r\n MessageBox.Show(\"Array is vol\");\r\n else\r\n {\r\n while (sender[i] != 0)\r\n {\r\n i++;\r\n }\r\n try { sender[i] = Convert.To" + $"{converterSender}" + "(<<< textbox >>>.Text); }\r\n catch { MessageBox.Show(\"foute input\"); }\r\n\r\n i = 0;\r\n }");
        }

        private void ToevoegenD(object sender)
        {
            lboxResult.Items.Clear();
            if (datatype == "int")
                converterSender = "Int32";

            if (datatype == "double")
                converterSender = "Double";

            if (datatype == "float")
                converterSender = "Single";

            if (datatype != "string")
            {
                converterSender = "String";
            }

            lboxResult.Items.Add("//Add an item from textbox \r \n if (sender[3, 1] != 0)\r\n MessageBox.Show(\"Array is vol\");\r\n //indien iets word toegevoegd op [4,0] word nieuwe collom aangemaakt\r\n\r\n else\r\n {\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n for (int j = 0; j < sender.GetLength(1); j++)\r\n {\r\n if (sender[k, j] == 0)\r\n {\r\n sender[k, j] = Convert.To"+$"{converterSender}"+"(txtItem.Text);\r\n lbResult.Items.Clear();\r\n lbResult2.Items.Clear();\r\n Uitlezen2D(sender);\r\n return;\r\n }\r\n }\r\n }\r\n }");
            lboxResult.Items.Add("//Add an item from 2 textbox to 2 parts in the 2D Array \r \n {\r\n if ((txtItem.Text != \"\") && (txtItem2.Text != \"\"))\r\n {\r\n MessageBox.Show(\"only one input please\");\r\n }\r\n\r\n if ((txtItem.Text == \"\") && (txtItem2.Text == \"\"))\r\n {\r\n MessageBox.Show(\"provide input please\");\r\n }\r\n\r\n else\r\n {\r\n if (txtItem.Text != \"\")\r\n {\r\n if (sender[3, 0] != 0)\r\n {\r\n MessageBox.Show(\"Array is vol\");\r\n }\r\n\r\n //indien iets word toegevoegd op [4,0] word nieuwe collom aangemaakt\r\n\r\n else\r\n {\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n if (sender[k, 0] == 0)\r\n {\r\n sender[k, 0] = Convert.To"+ $"{converterSender}" + "(txtItem.Text);\r\n Uitlezen2D(sender);\r\n txtItem.Clear();\r\n txtItem2.Clear();\r\n return;\r\n }\r\n }\r\n }\r\n }\r\n\r\n if (txtItem2.Text != \"\")\r\n {\r\n if (sender[3, 1] != 0)\r\n MessageBox.Show(\"Array is vol\");\r\n //indien iets word toegevoegd op [4,0] word nieuwe collom aangemaakt\r\n\r\n else\r\n {\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n if (sender[k, 1] == 0)\r\n {\r\n sender[k, 1] = Convert.To"+$"{converterSender}"+"(txtItem2.Text);\r\n Uitlezen2D(sender);\r\n txtItem.Clear();\r\n txtItem2.Clear();\r\n return;\r\n }\r\n }\r\n }\r\n }\r\n }");
        }

        private void Read (object sender)
        {
            lboxResult.Items.Clear();
            lboxResult.Items.Add("//Read out all items to listbox \r\n foreach (" + $"{sender}" + " in sender)\r\n {\r\n if (var != 0)\r\n {\r\n lbResult.Items.Add(var);\r\n }\r\n }}");
            lboxResult.Items.Add("//Read out all items to textbox \r \n StringBuilder sb = new StringBuilder();\r\nforeach (\" + $\"{sender}\" + \"var in sender)\r\n{\r\n if (var != 0)\r\n {\r\n sb.AppendLine(Convert.ToString(var));\r\n txtBox.Text = Convert.ToString(sb);\r\n }\r\n}");
        }

        private void ReadD(object sender)
        {
            lboxResult.Items.Clear();
            lboxResult.Items.Add(" //Read out all items in one listbox \r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n for (int j = 0; j < sender.GetLength(1); j++)\r\n {\r\n if (sender[k, j] != 0)\r\n {\r\n lbResult.Items.Add(sender[k, j]);\r\n }\r\n }\r\n }");
            lboxResult.Items.Add("//Read out all items in one textbox \r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n for (int j = 0; j < sender.GetLength(1); j++)\r\n {\r\n if (sender[k, j] != 0)\r\n {\r\n txtBox.Text = Convert.ToString(sender[k, j]);\r\n }\r\n }\r\n }");
            lboxResult.Items.Add(" //Read out result in first listbox\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n if (sender[k, 0] != 0)\r\n {\r\n lbResult.Items.Add(sender[k, 0]);\r\n }\r\n }\r\n\r\n //Read out result in second listbox\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n if (sender[k, 1] != 0)\r\n {\r\n lbResult2.Items.Add(sender[k, 1]);\r\n }\r\n }");
            lboxResult.Items.Add(" //Read out result in first textbox\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n if (sender[k, 0] != 0)\r\n {\r\n txtBox.Text = Convert.ToString(sender[k, 0]);\r\n }\r\n }\r\n\r\n //Read out result in second textbox\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n if (sender[k, 1] != 0)\r\n {\r\n txtBox2.Text = Convert.ToString(sender[k, 0]);\r\n }\r\n }");
        }

        private void Sort ()
        {
            lboxResult.Items.Clear();
            lboxResult.Items.Add("//Sort array \r \n Array.Sort(sender);");
            lboxResult.Items.Add("//Sort reverse array \r \n Array.Sort(sender);\r\nif (cbReverse.IsChecked == true)\r\n{\r\nArray.Reverse(sender);\r\n}");
        }

        private void SortD(object sender)
        {
            lboxResult.Items.Clear();
            lboxResult.Items.Add(" //Sort rows\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n for (int p = 0; p < sender.GetLength(0); p++)\r\n {\r\n if (sender[k, 0] < sender[p, 0])\r\n {\r\n "+$"{sender}"+ " grootste = sender[p, 0];\r\n "+$"{sender}"+" kleinste = sender[k, 0];\r\n sender[k, 0] = grootste;\r\n sender[p, 0] = kleinste;\r\n }\r\n else\r\n {\r\n "+$"{sender}"+" kleinste = sender[p, 0];\r\n "+$"{sender}"+" grootste = sender[k, 0];\r\n sender[k, 0] = grootste;\r\n sender[p, 0] = kleinste;\r\n }\r\n }\r\n }");
            lboxResult.Items.Add("//Sort rows in 2 different listboxes\r \n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n for (int p = 0; p < sender.GetLength(0); p++)\r\n {\r\n if (sender[k, 1] < sender[p, 1])\r\n {\r\n "+$"{sender}"+" grootste = sender[p, 1];\r\n "+$"{sender}"+" kleinste = sender[k, 1];\r\n //MessageBox.Show($\"kleiner {kleinste}\");\r\n //MessageBox.Show($\"grooter {grootste}\");\r\n sender[k, 1] = grootste;\r\n sender[p, 1] = kleinste;\r\n }\r\n else\r\n {\r\n "+$"{sender}"+" kleinste = sender[p, 1];\r\n "+$"{sender}"+" grootste = sender[k, 1];\r\n //MessageBox.Show($\"kleiner {kleinste}\");\r\n //MessageBox.Show($\"grooter {grootste}\");\r\n sender[k, 1] = grootste;\r\n sender[p, 1] = kleinste;\r\n }\r\n }\r\n }");
            lboxResult.Items.Add(" //reverse sort rows\r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n for (int p = 0; p < sender.GetLength(0); p++)\r\n {\r\n if (sender[k, 0] < sender[p, 0])\r\n {\r\n "+$"{sender}"+" kleinste = sender[p, 0];\r\n "+$"{sender}"+" grootste = sender[k, 0];\r\n sender[k, 0] = grootste;\r\n sender[p, 0] = kleinste;\r\n }\r\n else\r\n {\r\n "+$"{sender}"+" grootste = sender[p, 0];\r\n "+$"{sender}"+ " kleinste = sender[k, 0];\r\n sender[k, 0] = grootste;\r\n sender[p, 0] = kleinste;\r\n }\r\n }\r\n } \r\n for (int k = 0; k < sender.GetLength(0); k++)\r\n {\r\n for (int p = 0; p < sender.GetLength(0); p++)\r\n {\r\n if (sender[k, 1] < sender[p, 1])\r\n {\r\n "+$"{sender}"+" kleinste = sender[p, 1];\r\n "+$"{sender}"+" grootste = sender[k, 1];\r\n sender[k, 1] = grootste;\r\n sender[p, 1] = kleinste;\r\n }\r\n else\r\n {\r\n "+$"{sender}"+" grootste = sender[p, 1];\r\n "+$"{sender}"+" kleinste = sender[k, 1];\r\n sender[k, 1] = grootste;\r\n sender[p, 1] = kleinste;\r\n }\r\n }\r\n }");    
        }

        private void Delete(object sender)
        {
            lboxResult.Items.Clear();
            if (datatype == "int")
                converterSender = "Int32";

            if (datatype == "double")
                converterSender = "Double";

            if (datatype == "float")
                converterSender = "Single";

            if (datatype != "string")
            {
                converterSender = "String";
            }

            lboxResult.Items.Add("//selected item van listbox wissen uit array\r\n if (sender.Contains(Convert.To" +$"{converterSender}" +"(lbResult.SelectedItem)))\r\n {\r\n for (int i = 0; i < sender.Length; i++)\r\n {\r\n if (sender[i] == (int)lbResult.SelectedItem)\r\n {\r\n sender[i] = 0;\r\n for (int j = i + 1; j < sender.Length; j++)\r\n {\r\n sender[j - 1] = sender[j];\r\n sender[sender.Length - 1] = 0;\r\n }\r\n }\r\n }\r\n lbResult.Items.Clear();\r\n }\r\n else\r\n {\r\n return;\r\n }\r\n return;");
        }

        private void DeleteD(object sender)
        {
            lboxResult.Items.Clear();
            if (datatype == "int")
                converterSender = "Int32";

            if (datatype == "double")
                converterSender = "Double";

            if (datatype == "float")
                converterSender = "Single";

            if (datatype != "string")
            {
                converterSender = "String";
            }

            lboxResult.Items.Add(" //delete item from one listbox\r\n for (int i = 0; i < sender.GetLength(0); i++)\r\n {\r\n for (int j = 0; j < sender.GetLength(1); j++)\r\n {\r\n if (sender[i, j] == Convert.To"+$"{converterSender}"+"(lbResult.SelectedItem))\r\n {\r\n sender[i, j] = default("+$"{sender}"+");\r\n }\r\n }\r\n }");
            lboxResult.Items.Add(" //delete item from two listbox\r\n for (int i = 0; i < sender.GetLength(0); i++)\r\n {\r\n if (sender[i,0] == Convert.To"+$"{converterSender}"+"(lbResult.SelectedItem))\r\n {\r\n sender[i, 0] = default("+$"{sender}"+");\r\n }\r\n }\r\n\r\n for (int i = 0; i < sender.GetLength(0); i++)\r\n {\r\n if (sender[i, 1] == Convert.To"+$"{converterSender}"+"(lbResult2.SelectedItem))\r\n {\r\n sender[i, 1] = default("+$"{sender}"+");\r\n }\r\n }");
        }

        private void EmptyArray()
        {
            lboxResult.Items.Clear();
            lboxResult.Items.Add("//Array Leegmaken\r\n Array.Clear(sender, 0, sender.Length);\r\n lbResult.Items.Clear();");
        }

        private void EmptyArrayD()
        {
            lboxResult.Items.Clear();
            lboxResult.Items.Add(" //2D Array Leegmaken\r\n for (int i = 0; i < sender.GetLength(0); i++)\r\n {\r\n for (int j = 0; j < sender.GetLength(1); j++)\r\n {\r\n sender[i, j] = default;\r\n }\r\n }");
        }
    }
}
