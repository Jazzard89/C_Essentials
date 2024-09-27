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

namespace WPF_controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //XAML
        ////isEditable zorgt ervoor dat je hem niet kan veranderen van groote
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CboOpleiding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //indien we weten dat het text is kunnen we dit doen
            //MessageBox.Show(CboOpleiding.SelectedValue.ToString());

            if (CboOpleiding.SelectedIndex > -1) {

            

            //enkel de content van de combobox naar string voor message
            MessageBox.Show(((ComboBoxItem) CboOpleiding.SelectedItem).Content.ToString());


            //wis het geselecteerde nummer
            CboOpleiding.Items.Remove(CboOpleiding.SelectedItem);

            //wis specifieke nummmer in lijst
            CboOpleiding.Items.RemoveAt(3);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //variabele   instance  = new  class
            ComboBoxItem cboItem = new ComboBoxItem();
            cboItem.Content = "Een nieuwe opleiding";
            CboOpleiding.Items.Add(cboItem);


            //PHASE 1
            //item is de eerste, items zijn keuze
            StringBuilder sb = new StringBuilder();
            foreach (ListBoxItem item in LbxNamen.SelectedItems)
            {
                sb.AppendLine($"{item.Content}\n");
            }

            MessageBox.Show(sb.ToString());

            //ListBoxItem item = new ListBoxItem();
            //item.Content = "Nieuwe medewerker";
            //LbxNamen.Items.Add(item);
            // Op een positie toevoegen,
            //LbxNamen.Items(2, item);

        }
    }
}
