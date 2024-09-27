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
using Microsoft.VisualBasic;



namespace Orkest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<newEvent> events = new List<newEvent>();



        struct newEvent
        {
            public string TypeEvent;
            public string NaamEvent;
            public int AantalBezoekers;
        }



        List<string> eventTypes = new List<string>() { "festival", "orkest", "opera" };



        public MainWindow()
        {
            InitializeComponent();
            foreach (string eventType in eventTypes) { cbTypeEvent.Items.Add(eventType); }
        }



        private void BtnVoegEventToe_Click(object sender, RoutedEventArgs e)
        {
            newEvent tempEvent;
            tempEvent.TypeEvent = cbTypeEvent.SelectedValue.ToString();
            tempEvent.NaamEvent = txtNaamEvent.Text;
            tempEvent.AantalBezoekers = int.Parse(txtAantalBezoekers.Text);
            events.Add(tempEvent);
            eventsUitlezen();
        }



        private void eventsUitlezen()
        {
            lbEvent.Items.Clear();
            foreach (newEvent ev in events)
            {
                lbEvent.Items.Add($"{ev.TypeEvent} - {ev.NaamEvent}: {ev.AantalBezoekers}");
            }
        }



        private void BtnVerwijderEvent_Click(object sender, RoutedEventArgs e)
        {
            if (lbEvent.SelectedIndex != -1)
            {
                events.RemoveAt(lbEvent.SelectedIndex);
                lbEvent.Items.Clear();
                foreach (newEvent ev in events)
                {
                    lbEvent.Items.Add($"{ev.TypeEvent} - {ev.NaamEvent}: {ev.AantalBezoekers}");
                }
            }
        }



        private void VerwijderAlleEvents_Click(object sender, RoutedEventArgs e)
        {
            events.Clear();
        }



        private void MaakStandaardEvent_Click(object sender, RoutedEventArgs e)
        {
            newEvent tempEvent;
            tempEvent.TypeEvent = "orkest";
            tempEvent.NaamEvent = "jaarlijks optreden";
            tempEvent.AantalBezoekers = 100;
            events.Add(tempEvent);
            eventsUitlezen();
        }
        private void Afsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}